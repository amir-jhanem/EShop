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
        public OrderStatusView Status { get; set; } =  OrderStatusView.Progress;
        public string UserId { get; set; }

        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();

        public decimal GrandTotal { get; set; }

        public enum PaymentMethodView
        {
            Cash = 1,
            BankTransfer = 2,
            Paypal = 3
        }

        public enum OrderStatusView
        {
            Progress = 1,
            OnShipping = 2,
            Finished = 3
        }
    }
}
