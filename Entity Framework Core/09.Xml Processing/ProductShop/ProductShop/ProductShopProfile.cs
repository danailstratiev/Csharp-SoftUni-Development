using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUsersDto, User>();

            this.CreateMap<ImportProductDto, Product>();

            this.CreateMap<ImportCategoryDto, Category>();

            this.CreateMap<Product, ExportProductDto>();

            this.CreateMap<Product, ExportProductMiniDto>();

            this.CreateMap<User, ExportUserDto>()
                .ForMember(x => x.ProductsSold, y => y.MapFrom(x => x.ProductsSold));
        }
    }
}
