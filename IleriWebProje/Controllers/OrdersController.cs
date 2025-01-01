using IleriWebProje.Data.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IleriWebProje.Data.Services;
using IleriWebProje.Data.ViewModels;

namespace IleriWebProje.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ISkillsService _skillService;
        private readonly IOrdersService _ordersService;

        public OrdersController(ISkillsService skillService ,ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _skillService = skillService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
         {
             string userId = "";
             //string userRole = User.FindFirstValue(ClaimTypes.Role);

             var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId);
             return View(orders);
         }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _skillService.GetSkillByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _skillService.GetSkillByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress );
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }

        public IActionResult Payment()
        {
            var totalAmount = _shoppingCart.GetShoppingCartTotal();
            ViewData["TotalAmount"] = totalAmount;
            return View();
        }
    }
}
