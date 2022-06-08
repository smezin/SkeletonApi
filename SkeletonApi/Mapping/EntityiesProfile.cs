using AutoMapper;
using SkeletonApi.Models.Entities;
using SkeletonApi.Models.Entities.DTOs;
using System.Linq;

namespace SkeletonApi.Mapping
{
    public class EntityiesProfile : Profile
    {
        public EntityiesProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ProductsNames, opt => opt.MapFrom(src => src.Products.Select(p => p.ProductName).ToList()))
                ;
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName))
                ;
        }
    }
}
