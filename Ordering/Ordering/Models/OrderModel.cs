using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Models
{
    public class Order
    {
        public int ID { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public IList<OrderDetail> OrderDetail { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}
