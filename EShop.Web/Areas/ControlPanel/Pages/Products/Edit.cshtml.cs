using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop.Core.Entities;
using EShop.Infrastructure.Data;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;

namespace EShop.Web.Areas.ControlPanel.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public EditModel(IProductPageService productPageService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
        }


        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productPageService.Update(Product);

            return RedirectToPage("./Index");
        }
    }
}
