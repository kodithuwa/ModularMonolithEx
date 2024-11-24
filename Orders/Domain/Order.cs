using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
