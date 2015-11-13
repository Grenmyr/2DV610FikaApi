using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models
{
    public class Fika
    {

        public Fika(DateTime date, string pastry )
        {
            Date = date;
            Pastry = pastry;
        }

        public Fika(DateTime date, string pastry, string bakerEmail)
        {
            throw new NotImplementedException();
        }

        public DateTime Date { get; set; }

        public string Pastry { get; set; }

        public object BakerEmail { get; set; }
    }
}