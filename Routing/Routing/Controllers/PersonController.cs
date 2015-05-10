using Routing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Routing.Controllers
{
    public class PersonController : ApiController
    {
        Person[] persons = new Person[]{
            new Person{ Id=101, FirstName="Lionel", LastName="Messi", Age=26 },
            new Person{ Id=102, FirstName="Fernando", LastName="Alonso", Age=32 },
            new Person{ Id=103, FirstName="Cristiano", LastName="Ronaldo", Age=30 },
        };
        PersonDetail[] personDetail = new PersonDetail[]{
            new PersonDetail{ Id=1001, PersonId=101, Address1="Lionel", Address2="Messi", Country=26 },
            new PersonDetail{ Id=1002, PersonId=102, Address1="Fernando", Address2="Alonso", Country=32 },
            new PersonDetail{ Id=1003, PersonId=103, Address1="Cristiano", Address2="Ronaldo", Country=30 },
        };
        [HttpGet]
        public IEnumerable<Person> FindPersons()
        {
            return persons;
        }
        [HttpGet]
        public IHttpActionResult FindPersonById(int Id)
        {
            var person = persons.FirstOrDefault(per => per.Id == Id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpGet]
        [ActionName("Detail")]
        public HttpResponseMessage PersonDetail(int id)
        {
            if(id==null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Id is required");
            var detail = personDetail.FirstOrDefault(per => per.PersonId == id);
            if (detail == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person details not found");
            return Request.CreateResponse<PersonDetail>(HttpStatusCode.OK, detail);
        }
        [HttpDelete]
        public HttpResponseMessage DropPersonById(int id)
        {
            var person = persons.FirstOrDefault(per => per.Id == id);
            if (person == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person not found");
            return Request.CreateResponse<Person>(HttpStatusCode.OK, person);
        }
    }
}
