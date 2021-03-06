﻿using _2DV610FikaApi.Models;
using System;
using System.Collections.Generic;

namespace _2DV610FikaApi
{
    public interface IService
    {
        List<Fika> GetFikas();

        List<Baker> GetBakers();

        Baker GetBaker(int id);

        Baker AddBaker(Baker baker);

        Fika GetFika(int id);

        Fika AddFika(Fika fika);

        Baker DeleteBaker(int id);

        Fika DeleteFika(int id);

        Fika PutFika(Fika id);

        Baker PutBaker(int id);
    }
}
