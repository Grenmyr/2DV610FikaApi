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
            : this(new FikaRepository(), new BakerRepository())
        {}

        public Service(IFikaRepository fikaRepository, IBakerRepository bakerRepository)
        {
            _fikaRepository = fikaRepository;
            _bakerRepository = bakerRepository;
        }

        public List<Fika> GetFikas()
        {
            return _fikaRepository.GetFikas();
        }

        public List<Baker> GetBakers()
        {
            return _bakerRepository.GetBakers();
        }

        public Baker GetBaker(int id)
        {
            return _bakerRepository.GetBaker(id);
        }

        public Baker AddBaker(Baker baker)
        {
            return _bakerRepository.AddBaker(baker);
        }
    }
}