using _2DV610FikaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2DV610FikaApi.Controllers
{
    public class BakerController : ApiController
    {

        public IService _service;

        public BakerController()
            : this(new Service()){ }
        public BakerController(IService service)
        {
            _service = service;
        }

        public IHttpActionResult Get()
        {
            _service.GetBakers();
            return Ok(new List<Baker>());
        }
    }
}
