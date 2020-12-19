using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EShop.Core.Entities;
using EShop.Infrastructure.Data;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EShop.Web.Areas.ControlPanel.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public CreateModel(IProductPageService productPageService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productPageService.Create(Product);

            return RedirectToPage("./Index");
        }
    }
}
