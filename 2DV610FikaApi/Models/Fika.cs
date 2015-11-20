using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models
{
    public class Fika
    {
        private string _pastry;

        public DateTime Date { get; set; }

        public string Pastry
        {
            get 
            {
                return _pastry;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pastry value cannot be emty string or null.");
                }
                _pastry = value;
            }
        }
    }
}