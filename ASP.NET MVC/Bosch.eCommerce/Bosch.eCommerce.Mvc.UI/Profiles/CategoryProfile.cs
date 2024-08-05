using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.Mvc.UI.DTOs.CategoryDtos;

namespace Bosch.eCommerce.Mvc.UI.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            //Fetch Data to be displayed in view
            CreateMap<Category,CategoryDto>();
            //Insert/Update/Delete operations
            CreateMap<InsertCategoryDto, Category>();
        }
    }
}
