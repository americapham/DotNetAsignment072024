using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.Mvc.UI.DTOs.ProductDtos;

namespace Bosch.eCommerce.Mvc.UI.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            //Fetch
            CreateMap<Product,ProductDto>();
        }
    }
}
