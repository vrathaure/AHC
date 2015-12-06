using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationAPI2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime PeriodDate { get; set; }
        public string PeriodLabel { get; set; }
        public int Ordered { get; set; }
        public int Shipped { get; set; }
        public decimal TotalOrderedAmount { get; set; }
        public decimal TotalShippedAmount { get; set; }
    }
}