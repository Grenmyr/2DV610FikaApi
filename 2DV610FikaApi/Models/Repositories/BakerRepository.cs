using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models.Repositories
{
    public class BakerRepository : IBakerRepository
    {

        public List<Baker> GetBakers()
        {
            return new List<Baker>();
        }

        public Baker GetBaker(int id)
        {
            return new Baker("David", "david.grenmyr@gmail.com");
        }

        public Baker AddBaker(Baker baker)
        {
            return new Baker("Erik", "erik.magnusson@mail.com");
        }
    }
}