using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Areas.ControlPanel.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public IndexModel(IProductPageService productPageService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
        }
        public IEnumerable<ProductViewModel> ProductList { get; set; } = new List<ProductViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            ProductList = await _productPageService.GetProducts(SearchTerm);
        }
    }
}
