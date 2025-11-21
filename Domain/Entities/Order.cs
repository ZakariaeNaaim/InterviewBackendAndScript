using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set;}
        public int CustomerId { get; set; }
    }
}
