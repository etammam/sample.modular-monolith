using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Samples.ModularMonolith.Domain.Shared.Exceptions;
using Samples.ModularMonolith.Domain.Shared.Exceptions.Models;
using Samples.ModularMonolith.Infrastructure.Presentation.Configurations;
using System;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Middleware.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ExceptionConfiguration _exceptionConfiguration;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(IOptions<ExceptionConfiguration> exceptionConfiguration, IHostEnvironment hostEnvironment, ILogger<ExceptionMiddleware> logger)
        {
            if (exceptionConfiguration is not { })
                throw new ArgumentNullException(nameof(exceptionConfiguration));

            _exceptionConfiguration = exceptionConfiguration.Value;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception e)
            {
                _logger.LogError("raw exception type: {FullName}", e.GetType().FullName);
                _logger.LogError(exception: e, message: "raw exception");
                if (e.GetBaseException() is DomainException)
                {
                    var exception = (DomainException)e;
                    var error = exception.Error;
                    error.ExceptionType = exception.ExceptionType;
                    error.Message = exception.Message;
                    error.ErrorCode = exception.Error.ErrorCode;

                    if (_exceptionConfiguration.ShowExceptionStackTrace)
                        error.StackTrace = exception.StackTrace;
                    if (_exceptionConfiguration.ShowExceptionInnerException)
                        error.InnerException = exception.InnerException;

                    context.Response.StatusCode = exception.Error.StatusCode;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(error, JsonSerializerOptions()), Encoding.UTF8);
                }
                else if (e.GetBaseException() is ValidationException || e is ValidationException)
                {
                    var error = new ErrorModel();
                    var exception = (ValidationException)e;
                    error.Message = exception.Message;
                    error.ExceptionType = nameof(ValidationException);

                    if (_exceptionConfiguration.ShowExceptionStackTrace)
                        error.StackTrace = exception.StackTrace;
                    if (_exceptionConfiguration.ShowExceptionInnerException)
                        error.InnerException = exception.InnerException;

                    var errorProperties = exception.Errors.GroupBy(c => c.PropertyName);
                    foreach (var errorProperty in errorProperties)
                    {
                        var validationError = new ValidationError
                        {
                            PropertyName = errorProperty.Key
                        };
                        foreach (var validationFailure in errorProperty)
                            validationError.Validations.Add(new ErrorProperty(validationFailure.AttemptedValue, ConvertToExceptionSuffix(validationFailure.ErrorCode), validationFailure.ErrorMessage, validationFailure.Severity.ToString()));
                        error.Errors.Add(validationError);
                    }

                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(error, JsonSerializerOptions()), Encoding.UTF8);
                }
                else if (e.GetBaseException() is DbException || e is DbException || e.GetBaseException() is DbUpdateException || e is DbUpdateException)
                {
                    var error = new ErrorModel
                    {
                        Message = e.InnerException is not null ? e.InnerException.Message : e.Message,
                        ExceptionType = nameof(DbException)
                    };
                    if (_exceptionConfiguration.ShowExceptionStackTrace)
                        error.StackTrace = e.StackTrace;

                    if (_exceptionConfiguration.ShowExceptionInnerException)
                        error.InnerException = e.InnerException;

                    error.StatusCode = (int)HttpStatusCode.Conflict;
                    context!.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(error, JsonSerializerOptions()), Encoding.UTF8);
                }
                else
                {
                    var error = new ErrorModel
                    {
                        Message = e.Message,
                        ExceptionType = "InternalServerException"
                    };
                    if (_exceptionConfiguration.ShowExceptionStackTrace)
                        error.StackTrace = e.StackTrace;

                    if (_exceptionConfiguration.ShowExceptionInnerException)
                        error.InnerException = e.InnerException;

                    error.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context!.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(error, JsonSerializerOptions()), Encoding.UTF8);
                }
            }
        }

        private static JsonSerializerOptions JsonSerializerOptions()
        {
            return new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        private static string ConvertToExceptionSuffix(string validatorError)
        {
            return validatorError.Replace("Validator", "Exception");
        }
    }
}
