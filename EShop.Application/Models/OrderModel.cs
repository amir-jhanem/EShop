using EShop.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Models
{
    public class OrderModel : BaseModel
    {
        public string ShippingAddress { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }
        public OrderStatusModel Status { get; set; }
        public decimal GrandTotal { get; set; }

        public List<OrderItemModel> Items { get; set; } = new List<OrderItemModel>();
    }

    public enum OrderStatusModel
    {
        Progress = 1,
        OnShipping = 2,
        Finished = 3
    }

    public enum PaymentMethodModel
    {
        Check = 1,
        BankTransfer = 2,
        Cash = 3,
        Paypal = 4,
        Payoneer = 5
    }
}
