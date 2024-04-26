namespace Ecommerce.Application.MappingProfiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            //Configure AutoMapper 
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
