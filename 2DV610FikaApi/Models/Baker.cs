﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models
{
    public class Baker
    {
        private string name;
        public Baker(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }
            this.name = name;
        }
    }
}