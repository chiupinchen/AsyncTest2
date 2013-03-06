using AsyncTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AsyncTest2.Controllers
{
    public class ProcessController : ApiController
    {
        ChiupinDBEntities entity = new ChiupinDBEntities();

        
        public IEnumerable<Person> Get()
        {
            return entity.People.AsEnumerable();
        }

        public int Post(Person p)
        {
            entity.People.Add(p);
            return entity.SaveChanges();

        }

        // PUT api/default1/5
        public int Put(Person person)
        {
            Person personInDB = entity.People.First(p => p.ID == person.ID);
            entity.People.Remove(personInDB);
            entity.People.Add(person);
            return entity.SaveChanges();
        }

      
        public int Delete(int id)
        {
            Person person = entity.People.First(p => p.ID == id);
            entity.People.Remove(person);
            return entity.SaveChanges();
        }
    }
}
