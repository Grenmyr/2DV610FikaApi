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

        private IService _service;

        public FikaController(IService service)
        {
            _service = service;
        }

        public IHttpActionResult Get()
        {
            List<Fika>  list = _service.GetFikas();

            if (list == null)
            {
                return NotFound();
            }
           
            return Ok(list);
        }


        public IHttpActionResult Get(int id)
        {
            Fika fika = _service.GetFikaById(id);

            if (fika == null)
            {
                return NotFound();
            }

            return Ok(fika);
        }

        public IHttpActionResult Post(Fika fika) 
        {
            Fika copyOfFika = new Fika();
            try
            {          
                copyOfFika.Pastry = fika.Pastry;
                copyOfFika.Date = fika.Date;
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            
            return CreatedAtRoute("Default Api", new { id = copyOfFika.Id }, _service.AddFika(copyOfFika));
        }
    }
}