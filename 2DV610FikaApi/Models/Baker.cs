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

        public Baker(string name, string email)
        {
            if (String.IsNullOrEmpty(name) || name.Length > 20 || email.Length < 4 || email.Length > 254)
            {
                throw new ArgumentException();
            }
            this.name = name;
            this.email = email;
        }
    }
}