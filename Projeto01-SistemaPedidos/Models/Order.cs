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
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public double TotalAmout { get; set; }

        private Order() { }

        public Order(Customer customer, List<Product> products, DateTime orderDate, double totalAmout)
        {
            Customer = customer;
            Products = products;
            OrderDate = orderDate;
            TotalAmout = totalAmout;
        }
    }
}
