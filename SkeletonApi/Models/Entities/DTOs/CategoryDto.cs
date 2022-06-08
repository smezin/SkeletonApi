using System.Collections.Generic;

namespace SkeletonApi.Models.Entities.DTOs
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual List<string> ProductsNames { get; set; }
    }
}
