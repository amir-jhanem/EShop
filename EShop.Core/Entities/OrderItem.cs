using EShop.Core.Entities.Base;

namespace EShop.Core.Entities
{
    public class OrderItem : Entity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // n-1 relationships
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
