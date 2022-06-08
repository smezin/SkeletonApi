namespace SkeletonApi.Models.Entities.DTOs
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public double? UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        public string Category { get; set; }
    }
}
