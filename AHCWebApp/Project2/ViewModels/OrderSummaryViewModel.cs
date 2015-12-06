using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project2.Models;

namespace Project2.ViewModels
{
    public class OrderSummaryViewModel
    {
        public List<Order> orders;
        public decimal? orderAvg { get; set; }
        public decimal? orderTotal { get; set; }
        public decimal? shippedAvg { get; set; }
        public decimal? shippedTotal { get; set; }
        
    }
}