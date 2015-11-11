using _2DV610FikaApi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi
{
    public class Service
    {
        private IFikaRepository repository;

        public Service(IFikaRepository repository)
        {
            this.repository = repository;
        }
        public void GetFikas()
        {
            repository.GetFikas();
        }
    }
}