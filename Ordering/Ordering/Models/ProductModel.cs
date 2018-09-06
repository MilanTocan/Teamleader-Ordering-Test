using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
