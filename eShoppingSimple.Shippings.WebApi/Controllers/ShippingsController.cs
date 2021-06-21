using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShoppingSimple.Shippings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        // GET: api/<ShippingsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ShippingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();

        }

        // POST api/<ShippingsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();

        }

        // PUT api/<ShippingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();

        }

        // DELETE api/<ShippingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();

        }
    }
}
