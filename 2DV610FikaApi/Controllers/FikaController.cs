﻿using _2DV610FikaApi.Models;
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

        public IHttpActionResult Get()
        {
            List<Fika> list = new List<Fika>();
            list = _service.GetFikas();

            if (list == null)
            {
                return NotFound();
            }
           
            return Ok(list);
        }
    }
}