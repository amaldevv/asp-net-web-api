using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyApi.Models;

namespace MyApi.Controllers
{
    public class PersonController : ApiController
    {
        Person[] persons = new Person[]{
            new Person{ Id=101, FirstName="Lionel", LastName="Messi", Age=26 },
            new Person{ Id=102, FirstName="Fernando", LastName="Alonso", Age=32 },
            new Person{ Id=103, FirstName="Cristiano", LastName="Ronaldo", Age=30 },
        };        

        public IEnumerable<Person> GetAllPersons()
        {
            return persons;
        }

        public IHttpActionResult GetPerson(int Id)
        {
            var person = persons.FirstOrDefault(per => per.Id == Id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }
    }
}
