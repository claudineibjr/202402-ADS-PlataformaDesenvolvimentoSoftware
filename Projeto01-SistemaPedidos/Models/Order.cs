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
        public IEnumerable<OrderItem> Products { get; set; } = new List<OrderItem>();
        public double TotalAmount {
            get { return Products.Sum(pi => pi.Product.Price * pi.Quantity); }
            private set { }
        }

        private Order() { }

        public Order(Customer customer, List<OrderItem> products, DateTime orderDate)
        {
            Customer = customer;
            Products = products;
            OrderDate = orderDate;
        }
    }
}
