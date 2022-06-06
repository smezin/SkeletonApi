using System;

namespace SkeletonApi.Models.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
