using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projeto01_OrdersManager.DTOs;

namespace Projeto01_OrdersManager.Models
{
    public class Order
    {
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Products { get; set; } = new List<OrderItem>();
        public double TotalAmount { get
            {
                return Products.Sum((product) => product.Quantity * product.Product.Price);
            } private set {}
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
