using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.Mvc.UI.DTOs.ProductDtos;
using Bosch.eCommerce.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Bosch.eCommerce.Mvc.UI.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        private readonly ICommonRepository<Product> _productRepository;
        private readonly ICommonRepository<Category> _categoryRepository;
        private readonly IMemoryCache _productsCache;
        private readonly IMapper _mapper;
        public HomeController(ICommonRepository<Product> productRepository, ICommonRepository<Category> categoryRepository, IMemoryCache productsCache, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productsCache = productsCache;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Welcome To Bosch Products List!";
            IEnumerable<ProductDto> cachedProducts;
            if (_productsCache.TryGetValue("ProductsList", out cachedProducts))
            {
                return View(cachedProducts);
            }
            MemoryCacheEntryOptions cacheOptions = new()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(2),
                SlidingExpiration = new TimeSpan(0, 0, 40)
            };
            var products = _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAllAsync());
            _productsCache.Set("ProductsList", products, cacheOptions);
            return View(products);
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetDetailsAsync(id);
            ViewBag.PageTitle = $"Details Of - {product.ProductName}!";

            return View(product);
        }

        public async Task<IActionResult> CategoryWiseProducts(int id)
        {
            string categoryName = (await _categoryRepository.GetDetailsAsync(id)).CategoryName;
            ViewBag.PageTitle = $"Bosch Products List From Category - {categoryName}!";
            var products = _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAllAsync()).Where(product => product.CategoryId == id);
            return View("Index", products);
        }

    }
}
