using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models
{
    public class Baker
    {
        private string name;
        private string email;
        public Baker(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }
            this.name = name;
        }

        public Baker(string name, string email)
        {
            if (email.Length < 4)
            {
                throw new ArgumentException();
            }
            this.email = email;
        }
    }
}