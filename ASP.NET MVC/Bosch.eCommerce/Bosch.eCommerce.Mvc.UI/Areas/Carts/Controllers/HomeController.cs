using AutoMapper;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.Mvc.UI.DTOs.CartItemDtos;
using Bosch.eCommerce.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.eCommerce.Mvc.UI.Areas.Carts.Controllers
{
    [Area("Carts")]
    public class HomeController : Controller
    {
        private readonly ICommonRepository<CartItem> _cartItemRepository;
        private readonly IGenerateCart _generateCart;
        private readonly IMapper _mapper;
        public HomeController(ICommonRepository<CartItem> cartItemRepository, IGenerateCart generateCart, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _generateCart = generateCart;
            _mapper = mapper;
        }
        public async Task<IActionResult> YourCartItems()
        {
            if (HttpContext.Session.GetInt32("CartId") == null)
            {
                ViewBag.NoItemsInCartMessage = "Your Cart is Empty";
                return View();
            }
            var cartDetailsData = await _generateCart.GetCartItems((int)HttpContext.Session.GetInt32("CartId"));
            if (cartDetailsData.Count <= 0)
            {
                ViewBag.NoItemsInCartMessage = "Your Cart is Empty";
            }
            return View(cartDetailsData);
        }
        public async Task<IActionResult> AddToCart(int productId)
        {
            HttpContext.Session.SetInt32("CustomerId", 1);
            if (HttpContext.Session.GetInt32("CartId") == null)
            {
                int cartId = await _generateCart.GenerateNewCart((int)HttpContext.Session.GetInt32("CustomerId"));
                HttpContext.Session.SetInt32("CartId", cartId);
            }
            var cartItemDto = new InsertCartItemDto()
            {
                CartId = (int)HttpContext.Session.GetInt32("CartId"),
                ProductId = productId,
            };
            var cartItem = _mapper.Map<CartItem>(cartItemDto);
            int result = await _cartItemRepository.InsertAsync(cartItem);
            if (result > 0)
            {
                return RedirectToAction("YourCartItems");
            }

            return RedirectToAction("AddToCart");
        }
    }
}
