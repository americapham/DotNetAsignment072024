using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.Mvc.UI.DTOs.CartItemDtos;

namespace Bosch.eCommerce.Mvc.UI.Profiles
{
    public class CartItemProfile:Profile
    {
        public CartItemProfile() 
        {
            CreateMap<InsertCartItemDto, CartItem>();
        }
    }
}
