using System;
using System.ComponentModel.DataAnnotations;

namespace HumbleBob.Dal.Entities
{
    public class BaseEntity
    {
        [Key] public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}