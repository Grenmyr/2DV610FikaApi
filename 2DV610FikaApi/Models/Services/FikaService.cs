using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models.Services
{
    public class FikaService : IFikaService
    {
        public FikaService() { }

        public String Get() 
        {
            return "Test";
        }
    }
}