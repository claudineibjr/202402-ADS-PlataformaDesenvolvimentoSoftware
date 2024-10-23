namespace Core.DTOs
{
    public class OrderDTO
    {
        public ICollection<ProductItemDTO> Products { get; set; }
    }
}
