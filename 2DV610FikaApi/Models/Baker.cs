using System;
using System.Collections.Generic;
using System.Linq;



namespace _2DV610FikaApi.Models
{
    public class Baker
    {
        private string _name;
        private string _email;

        public Baker(string name, string email)
        {
            if (name == null 
                || !Extensions.IsWithin(name.Length , 1, 20) 
                || !Extensions.IsWithin(email.Length, 4, 254))
            {
                throw new ArgumentException();
            }
            _name = name;
            _email = email;
        }

        public string Email 
        {
            get { return _email; }
        }

        public List<Fika> Fikas { get; set; }
        public int Id { get; set; }
    }
}