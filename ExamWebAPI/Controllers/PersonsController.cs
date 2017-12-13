using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonStore.Models;

namespace PersonStore.Controllers
{
    public class PersonsController : ApiController
    {
        IPersonRepository _repository;

        public PersonsController(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var product = _repository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }
    }
}
