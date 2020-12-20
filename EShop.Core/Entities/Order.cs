using EShop.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Core.Entities
{
    public class Order : Entity
    {
        public string ShippingAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }
        public decimal GrandTotal { get; set; }

        // n-1 relationships
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        // 1-n relationships
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

    public enum OrderStatus
    {
        Progress = 1,
        OnShipping = 2,
        Finished = 3
    }

    public enum PaymentMethod
    {
        Cash = 1,
        BankTransfer = 2,
        Paypal = 3
    }
}
