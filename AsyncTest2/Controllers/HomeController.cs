using AsyncTest2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsyncTest2.Controllers
{
    public class HomeController : Controller
    {

        static string _address = "http://localhost:38998/api/Bing/1";
        static string _address2 = "http://localhost:38998/api/Bing";

        static string _address3 = "http://localhost:38998/api/Bing";

        public ActionResult Index()
        {
            

            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public async Task<ActionResult> About()
        {
            //make api calls from server side

            var client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:38998/api/Bing/1");
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response1 = await client.GetAsync(_address);
            HttpResponseMessage response2 = await client.GetAsync(_address2);


            
           
            Product product = await response1.Content.ReadAsAsync<Product>();
            IEnumerable<Product> products2 = await response2.Content.ReadAsAsync<IEnumerable<Product>>();


            HttpResponseMessage response3 = await client.PostAsJsonAsync(_address2, products2);
            
            
            ViewBag.Message = "Your app description page.";




            return View(product);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
