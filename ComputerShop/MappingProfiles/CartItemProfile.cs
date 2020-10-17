using AutoMapper;
using ComputerShop.Models;

namespace ComputerShop.MappingProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<Product, CartItem>().ReverseMap();
        }
    }
}
