using _2DV610FikaApi.Models;
using System;
using System.Collections.Generic;

namespace _2DV610FikaApi
{
    public interface IService
    {
        List<Fika> GetFikas();

        List<Baker> GetBakers();
    }
}
