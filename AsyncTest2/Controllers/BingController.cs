﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AsyncTest2.Models;

namespace AsyncTest2.Controllers
{

    public class Person
    {
        public string name { get; set; }
        public string email { get; set; }
    }


    public class BingController : ApiController
    {
        Product[] products = new Product[]  
        {  
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1.39M },  
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },  
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }  
        }; 
        
        


        // GET api/default1
        public IEnumerable<Product> Get()
        {
            return products; 
 
        }

        // GET api/default1/5
        public Product Get(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        // POST api/default1
        public HttpResponseMessage Post(Person person)
        {
            var p = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Ambiguous
            };


            return p;
        }

        // PUT api/default1/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
        }
    }
}
