using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models
{
    public class Fika
    {

        public Fika(DateTime date)
        {
            Date = date;
        }

        public Fika(string name)
        {
            // TODO: Complete member initialization
            Name = name;
        }
        public DateTime Date { get; set; }

        public object Name { get; set; }
    }
}