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

        private IService _service;

         public BakerController()
            :this(new Service()){}

        public BakerController(IService service)
        {
            _service = service;
        }

        public IHttpActionResult Get()
        {
            return Ok(_service.GetBakers());
        }

        public IHttpActionResult Get(int id)
        {
            var baker = _service.GetBaker(id);

            if (baker == null)
            {
                return NotFound();
            }
  
            return Ok(_service.GetBaker(id));
        }

        public IHttpActionResult Post(Baker baker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return CreatedAtRoute("Default Api", new { id = baker.Id }, _service.AddBaker(baker));
        }

        public IHttpActionResult Put(Baker baker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            throw new NotImplementedException();
        }

        public IHttpActionResult Delete(int id)
        {
            Baker baker = _service.DeleteBaker(id);
            if (baker == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
