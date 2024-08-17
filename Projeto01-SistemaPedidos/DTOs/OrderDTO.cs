namespace Projeto01_OrdersManager.DTOs
{
    public class OrderDTO
    {
        public string CustomerId { get; set; }
        public ICollection<ProductItemDTO> Products { get; set; }
    }
}
