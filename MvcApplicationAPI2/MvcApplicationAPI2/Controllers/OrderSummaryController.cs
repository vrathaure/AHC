using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplicationAPI2.Models;

namespace MvcApplicationAPI2.Controllers
{
    public class OrderSummaryController : ApiController
    {
        Order[] orders = new Order[]{};

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public IEnumerable<Order> WeekOverWeek()
        {
            return orders;
        }
    }
}
