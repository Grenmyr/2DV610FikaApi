using _2DV610FikaApi.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2DV610FikaApi.Controllers
{
    public class FikaController : ApiController
    {

        IFikaService _service;

        public FikaController(IFikaService fikaService) {
            _service = fikaService;
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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}