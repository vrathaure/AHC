using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Project2.Models;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Project2.ViewModels;

namespace Project2.Controllers
{
    public class OrderSummaryController : Controller
    {
        static string _address = "http://ahcwebapi.azurewebsites.net";
        OrderSummaryViewModel orderDetails = new OrderSummaryViewModel();
       
        private void GetData(string uri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_address);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetAsync(uri)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  var js = new JavaScriptSerializer();
                  var deserializedOrders = js.Deserialize<List<Order>>(jsonString.Result);
                  orderDetails.orders = deserializedOrders;
              });
            task.Wait();
            UpdateAggregates();
        }
        
        private void UpdateAggregates() {
            orderDetails.orderTotal = Math.Round(orderDetails.orders.Sum(item => item.TotalOrderedAmount), 2);
            orderDetails.orderAvg = Math.Round(Convert.ToDecimal(orderDetails.orderTotal / orderDetails.orders.Sum(item => item.Ordered)), 2);
            orderDetails.shippedTotal = Math.Round(orderDetails.orders.Sum(item => item.TotalOrderedAmount),2);
            orderDetails.shippedAvg = Math.Round(Convert.ToDecimal(orderDetails.shippedTotal/orderDetails.orders.Sum(item => item.Shipped)), 2);
            return;
        }

        public ActionResult Index()
        {
            GetData("/api/ordersummary/weekoverweek");
            return View(orderDetails);
        }

        public ActionResult Month()
        {
            GetData("/api/ordersummary/monthovermonth");
            return View(orderDetails);
        }

        public ActionResult Year()
        {
            GetData("/api/ordersummary/yearoveryear");
            return View(orderDetails);
        }
    }
}
