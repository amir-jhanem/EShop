using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages
{
    public class OrderSubmittedModel : PageModel
    {
        public int OrderId { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderId = id.Value;
            return Page();
        }
    }
}
