using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.Mvc.UI.DTOs.CategoryDtos;
using Bosch.eCommerce.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.eCommerce.Mvc.UI.Areas.Categories.Controllers
{
    [Area("Categories")]
    public class HomeController : Controller
    {
        private readonly ICommonRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public HomeController(ICommonRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Welcome To Bosch Categories List!";
            var categories = _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAllAsync());
            return View(categories);
        }
        //GET Method
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }
        //POST Method
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(InsertCategoryDto category)//Model Binding
        {
            var newCat = _mapper.Map<Category>(category);
            if (ModelState.IsValid)
            {
                int result = await _categoryRepository.InsertAsync(newCat);
                if (result>0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
