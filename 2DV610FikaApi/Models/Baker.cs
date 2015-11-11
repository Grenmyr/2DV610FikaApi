using System;
using System.Linq;



namespace _2DV610FikaApi.Models
{
    public class Baker
    {
        private string name;
        private string email;

        public Baker(string name, string email)
        {
            if (name == null 
                || Extensions.IsWithin(name.Length , 0, 20) 
                || Extensions.IsWithin(email.Length, 4, 254))
            {
                throw new ArgumentException();
            }
            this.name = name;
            this.email = email;
        }

        
    }
}