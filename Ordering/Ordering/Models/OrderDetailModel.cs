using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Ordering.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be bigger than 0 and less than 100!")]
        public int Quantity { get; set; }

        public string ProductId { get; set; }
        public int OrderId { get; set; }

        [ScriptIgnore]
        public virtual Product Product { get; set; }
        [ScriptIgnore]
        public Order Order { get; set; }
    }
}