using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace MvcApplicationAPI2
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            //string url = "http://ahcwebapi.azurewebsites.net";
            WebClient twitter = new WebClient();   
            // The base URL for Twitter API requests.  
            string baseUrl = "http://ahcwebapi.azurewebsites.net";   
            // The specific API call that we're interested in.  
            string request = "/api/ordersummary/weekoverweek";   
            // Make a request to the API and capture its result.  
            string response = twitter.DownloadString(baseUrl + request);  
            // Set the content-type so that libraries like jQuery can   
            //  automatically parse the result.  
            context.Response.ContentType = "application/json";   
            // Relay the API response back down to the client.  
            context.Response.Write(response);        
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}