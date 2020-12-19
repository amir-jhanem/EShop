using EShop.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
    }
}
