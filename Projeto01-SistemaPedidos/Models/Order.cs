namespace Projeto01_OrdersManager.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Product> Products { get; set; }
        public double TotalAmout { get; set; }
    }
}
