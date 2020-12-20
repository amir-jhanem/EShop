using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Areas.ControlPanel.Pages
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IOrderPageService _orderPageService;
        private readonly IProductPageService _productPageService;

        public IndexModel(IOrderPageService orderPageService, IProductPageService productPageService)
        {
            _orderPageService = orderPageService;
            _productPageService = productPageService;
        }

        public int OrdersCount { get; set; }
        public int ProductsCount { get; set; }

        public async Task OnGetAsync()
        {
            OrdersCount = (await _orderPageService.GetOrders()).Count();
            ProductsCount = (await _productPageService.GetProducts("")).Count();
        }
    }
}
