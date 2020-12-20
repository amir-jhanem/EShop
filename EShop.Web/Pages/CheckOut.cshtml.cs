using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace EShop.Web.Pages
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
        private readonly ICheckOutPageService _checkOutPageService;
        private readonly IProductPageService _productPageService;
        private readonly UserManager<IdentityUser> _userManager;

        public CheckOutModel(ICheckOutPageService checkOutPageService, IProductPageService productPageService, UserManager<IdentityUser> userManager)
        {
            _checkOutPageService = checkOutPageService ?? throw new ArgumentNullException(nameof(checkOutPageService));
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public ProductViewModel Product { get; set; }

        [BindProperty]
        public int ProductId { get; set; }
        [BindProperty]
        public OrderViewModel Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productPageService.GetProductById(id.Value);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Product = await _productPageService.GetProductById(ProductId);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.Items = new List<OrderItemViewModel>() 
            { 
                new OrderItemViewModel
                {
                    ProductId = Product.Id,
                    Quantity = 1,
                    TotalPrice = Product.UnitPrice.Value,
                    UnitPrice = Product.UnitPrice.Value
                }
            };

            var order = await _checkOutPageService.CheckOut(Order, _userManager.GetUserId(User));
            return RedirectToPage("OrderSubmitted", new { id = order.Id });
        }
    }
}
