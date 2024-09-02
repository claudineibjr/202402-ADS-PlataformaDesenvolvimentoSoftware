using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto01_OrdersManager.Models
{
    public class OrderItem
    {
        public string Id { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}
