namespace Application.Domain.Entities.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Interfaces;

    public abstract class BaseModel<TKey> : IAuditableEntity
    {
        [Key]
        public TKey Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
