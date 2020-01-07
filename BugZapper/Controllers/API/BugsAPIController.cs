using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugZapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugZapper.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsAPIController : ControllerBase
    {
        List<BugsModel> bug = new List<BugsModel>();

        // GET: api/BugsAPI
        [HttpGet]
        public List<BugsModel> Get()
        {
           // bug.Add(new BugsModel { BugID = })
            return bug;
        }

        // GET: api/BugsAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BugsAPI
        [HttpPost]
        public void Post(BugsModel value)
        {
            bug.Add(value);
        }

        // PUT: api/BugsAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
