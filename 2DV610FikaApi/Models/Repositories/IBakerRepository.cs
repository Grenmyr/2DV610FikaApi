﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DV610FikaApi.Models.Repositories
{
    public interface IBakerRepository
    {
        List<Baker> Get();
    }
}