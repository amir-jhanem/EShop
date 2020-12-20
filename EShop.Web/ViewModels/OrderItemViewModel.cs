using EShop.Web.ViewModels.Base;

namespace EShop.Web.ViewModels
{
    public class OrderItemViewModel : BaseViewModel
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
