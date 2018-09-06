using Ordering.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ordering.ViewModels
{
    public class OrderDetailEditViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        public IList<OrderDetail> OrderDetail { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }

        public IDictionary<string, decimal> Prices { get; set; }
        
        public decimal Total { get; set; }
    }
}