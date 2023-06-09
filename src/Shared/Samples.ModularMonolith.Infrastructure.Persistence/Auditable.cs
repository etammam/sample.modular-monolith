﻿using System;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    public abstract class Auditable
    {
        /// <summary>
        ///     the entity entry creation date
        /// </summary>
        public DateTime CreationDate { get; protected set; }

        /// <summary>
        ///     who's create this record, default value is empty string
        /// </summary>
        public string CreatedByName { get; protected set; } = string.Empty;

        /// <summary>
        ///     the id of the creator
        /// </summary>
        public Guid CreatedById { get; protected set; }

        /// <summary>
        ///     the date of last modification over this entry
        /// </summary>
        public DateTime? ModificationDate { get; protected set; }

        /// <summary>
        ///     who's modify this entry
        /// </summary>
        public string ModifiedByName { get; protected set; }

        /// <summary>
        ///     the id of modifier
        /// </summary>
        public Guid? ModifiedById { get; protected set; }

        /// <summary>
        ///     is the instance is active or not also this will reflect into inactivation date.
        /// </summary>
        public bool? IsActive => InactiveDate == null;

        /// <summary>
        ///     the instance inactivation date
        /// </summary>
        public DateTime? InactiveDate { get; protected set; }

        /// <summary>
        /// a sequential number auto generated by sequence in sql.
        /// </summary>
        public int SerialNumber { get; protected set; }

        /// <summary>
        ///     set the creator user id.
        /// </summary>
        /// <param name="createdById"></param>
        public void SetCreatedById(Guid createdById)
        {
            CreatedById = createdById;
        }

        /// <summary>
        ///     set the creator user name
        /// </summary>
        /// <param name="createdByName"></param>
        public void SetCreatedByName(string createdByName)
        {
            CreatedByName = createdByName;
        }

        /// <summary>
        ///     set the creation date.
        /// </summary>
        /// <param name="creationDateTime"></param>
        public void SetCreationDate(DateTime creationDateTime)
        {
            CreationDate = creationDateTime;
        }

        /// <summary>
        ///     set the modifier by user id.
        /// </summary>
        /// <param name="modifiedById"></param>
        public void SetModifiedById(Guid modifiedById)
        {
            ModifiedById = modifiedById;
        }

        /// <summary>
        ///     set the modifier user name.
        /// </summary>
        /// <param name="modifiedByName"></param>
        public void SetModifiedByName(string modifiedByName)
        {
            ModifiedByName = modifiedByName;
        }

        /// <summary>
        ///     set the instance modification date.
        /// </summary>
        /// <param name="modificationDate"></param>
        public void SetModificationDate(DateTime modificationDate)
        {
            ModificationDate = modificationDate;
        }

        /// <summary>
        ///     toggle the instance activation state and this will reflect into the instance inactive date.
        /// </summary>
        /// <param name="isActive"></param>
        public void SetIsActive(bool isActive)
        {
            InactiveDate = isActive ? null : DateTime.UtcNow;
        }

        /// <summary>
        ///     set the inactivation date.
        /// </summary>
        /// <param name="inactiveDate"></param>
        public void SetInactiveDate(DateTime inactiveDate)
        {
            InactiveDate = inactiveDate;
        }
    }
}
