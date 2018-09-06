using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Since { get; set; }

        [DataType(DataType.Currency)]
        public decimal Revenue { get; set; }
    }
}
