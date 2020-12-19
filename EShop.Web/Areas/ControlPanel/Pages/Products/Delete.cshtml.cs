using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EShop.Web.Areas.ControlPanel.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public DeleteModel(IProductPageService productPageService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productPageService.GetProductById(id.Value);

            if (Product != null)
            {
                await _productPageService.Delete(Product);
            }

            return RedirectToPage("./Index");
        }
    }
}
