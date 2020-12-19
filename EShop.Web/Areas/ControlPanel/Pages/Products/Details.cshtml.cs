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

namespace EShop.Web.Areas.ControlPanel.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public DetailsModel(IProductPageService productPageService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
        }

        public ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productPageService.GetProductById(id.Value);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
