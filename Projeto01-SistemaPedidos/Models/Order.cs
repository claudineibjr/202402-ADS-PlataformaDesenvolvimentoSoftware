namespace Projeto01_OrdersManager.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public ICollection<Product> Produtos { get; set; }
    }
}
