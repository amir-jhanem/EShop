using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EShop.Core.Entities;
using EShop.Infrastructure.Data;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EShop.Web.Areas.ControlPanel.Pages.Orders
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IOrderPageService _orderPageService;

        public IndexModel(IOrderPageService orderPageService)
        {
            _orderPageService = orderPageService;
        }

        public IEnumerable<OrderViewModel> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _orderPageService.GetOrders();
        }
    }
}
