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
        private IBakerRepository _bakerRepository;

        public Service()
        {
            _fikaRepository = new FikaRepository();
            _bakerRepository = new BakerRepository();
        }

        public Service(IFikaRepository fikaRepository)
        {
            _fikaRepository = fikaRepository;
        }

        public Service(IBakerRepository bakerRepository)
        {
            // TODO: Complete member initialization
            _bakerRepository = bakerRepository;
        }

        public List<Fika> GetFikas()
        {
            return _fikaRepository.GetFikas();
        }

        public List<Baker> GetBakers()
        {
            var bakers = _bakerRepository.GetBakers();
            if (bakers == null) {
                return new List<Baker>();
            }
            return bakers;
        }

        public Baker GetBaker(int id)
        {
            return _bakerRepository.GetBaker(id);
        }

        public Baker AddBaker(Baker baker)
        {
            return _bakerRepository.AddBaker(baker);
        }

        public Fika GetFikaById(int id)
        {
            throw new NotImplementedException();
        }


        public Fika AddFika(Fika fika)
        {
            throw new NotImplementedException();
        }

        public Baker DeleteBaker(int id)
        {
            throw new NotImplementedException();
        }
    }
}