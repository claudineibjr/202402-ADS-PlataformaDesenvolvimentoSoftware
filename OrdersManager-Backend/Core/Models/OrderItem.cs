namespace Core.Models
{
    public class OrderItem
    {
        public string Id { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}
