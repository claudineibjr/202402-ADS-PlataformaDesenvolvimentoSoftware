using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto01_OrdersManager.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Products { get; set; } = new List<OrderItem>();
        public double TotalAmount { get; set; }

        private Order() { }

        public Order(Customer customer, List<OrderItem> products, DateTime orderDate, double totalAmount)
        {
            Customer = customer;
            Products = products;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
        }
    }
}
