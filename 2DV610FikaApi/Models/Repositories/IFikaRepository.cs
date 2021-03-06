﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610FikaApi.Models.Repositories
{
    public interface IFikaRepository
    {
        List<Fika> GetFikas();

        Fika GetFika(int id);

        Fika AddFika(Fika id);

        Fika DeleteFika(Fika fika);
    }
}
