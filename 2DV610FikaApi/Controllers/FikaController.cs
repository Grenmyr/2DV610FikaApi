using _2DV610FikaApi.Models;
using _2DV610FikaApi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _2DV610FikaApi.Controllers
{
    public class FikaController : ApiController
    {

        public IService _service;

        public FikaController()
            : this(new Service()){ }
        public FikaController(IService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok("test");
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Fika value)
        {
            return Ok("fika");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Fika value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}