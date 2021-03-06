﻿using _2DV610FikaApi.Models;
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

        public Fika GetFika(int id)
        {
            return _fikaRepository.GetFika(id);
        }


        public Fika AddFika(Fika fika)
        {
            return _fikaRepository.AddFika(fika);
        }

        public Baker DeleteBaker(int id)
        {
            Baker baker = GetBaker(id);
            if (baker != null)
            {
                _bakerRepository.DeleteBaker(baker);
            }
            return baker;
        }

        public Fika DeleteFika(int id)
        {
            Fika fika = _fikaRepository.GetFika(id);

            if (fika != null)
            {
                _fikaRepository.DeleteFika(fika);
            }

            return fika;
        }


        public Fika PutFika(Fika fika)
        {
            Fika f = _fikaRepository.GetFika(fika.Id);
            return _fikaRepository.AddFika(f);
        }

        public Baker PutBaker(int id)
        {
            Baker baker = GetBaker(id);
            return _bakerRepository.PutBaker(baker);
        }
    }
}