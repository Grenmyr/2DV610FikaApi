using _2DV610FikaApi.Models;
using _2DV610FikaApi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi
{
    public class Service : IService
    {
        public IFikaRepository _fikaRepository;

        public Service()
        {
            _fikaRepository = new FikaRepository();
        }

        public Service(IFikaRepository fikaRepository)
        {
            _fikaRepository = fikaRepository;
        }

        public void GetFikas()
        {
            _fikaRepository.GetFikas();
        }
    }
}