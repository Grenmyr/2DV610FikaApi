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
        private IBakerRepository bakerRepository;

        public Service()
        {
            _fikaRepository = new FikaRepository();
        }

        public Service(IFikaRepository fikaRepository)
        {
            _fikaRepository = fikaRepository;
        }

        public Service(IBakerRepository bakerRepository)
        {
            // TODO: Complete member initialization
            this.bakerRepository = bakerRepository;
        }

        public List<Fika> GetFikas()
        {
            return _fikaRepository.GetFikas();
        }
    }
}