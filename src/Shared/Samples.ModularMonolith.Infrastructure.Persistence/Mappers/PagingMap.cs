using AutoMapper;
using Samples.ModularMonolith.Infrastructure.Persistence.Paging;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Mappers
{
    internal class PagingMap : Profile
    {
        public PagingMap()
        {
            CreateMap(typeof(PageResponse<>), typeof(PageResponse<>));
        }
    }
}
