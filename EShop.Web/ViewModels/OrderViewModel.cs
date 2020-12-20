using EShop.Web.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        [Required]
        public string ShippingAddress { get; set; }
        [Required]
        public PaymentMethodView PaymentMethod { get; set; }
        public int Status { get; set; } = 1; // Processing

        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();

        public decimal GrandTotal
        {
            get
            {
                decimal grandTotal = 0;
                foreach (var item in Items)
                {
                    grandTotal += item.TotalPrice;
                }

                return grandTotal;
            }
        }

        public enum PaymentMethodView
        {
            Cash = 1,
            BankTransfer = 2,
            Paypal = 3
        }
    }
}
