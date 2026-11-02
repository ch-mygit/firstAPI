using Microsoft.AspNetCore.Mvc;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class passwordsController : ControllerBase
    {
        // GET: api/<passwordsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<passwordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<passwordsController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            var v =Zxcvbn.Core.EvaluatePassword(value);
            return Ok(v.Score);
        }

        // PUT api/<passwordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<passwordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
