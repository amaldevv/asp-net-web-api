using ExceptionHandling.Filters;
using ExceptionHandling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExceptionHandling.Controllers
{
    public class PersonController : ApiController
    {
        Person[] persons = new Person[]{
            new Person{ Id=101, FirstName="Lionel", LastName="Messi", Age=26 },
            new Person{ Id=102, FirstName="Fernando", LastName="Alonso", Age=32 },
            new Person{ Id=103, FirstName="Cristiano", LastName="Ronaldo", Age=30 },
        };
        [HttpGet]
       // [ActionName("GetAllPersons")]
        public IEnumerable<Person> GetAllPersons()
        {
            return persons;
        }

        /*public IHttpActionResult GetPerson(int Id)
        {
            var person = persons.FirstOrDefault(per => per.Id == Id);
            if (person == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(person);
        }*/
        [HttpGet]
        
        public IHttpActionResult GetPerson(int Id)
        {
            var person = persons.FirstOrDefault(per => per.Id == Id);
            if (person == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(String.Format("No products with ID ={0}", Id)),
                    ReasonPhrase = "Product ID not found"
                };
                throw new HttpResponseException(response);
            }
            return Ok(person);
        }

        [NotImplementedExecFilter]
        [HttpPost]
        public IHttpActionResult CreatePerson(Person person)
        {
            throw new NotImplementedException("This method is under contruction");
        }
    }
}
