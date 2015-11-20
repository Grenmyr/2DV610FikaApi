using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models
{
    public class Fika
    {
        
        public Fika(DateTime date, string pastry)
        {
            Date = date;
            Pastry = pastry;
        }

        public Fika()
        {
            // TODO: Complete member initialization
        }

        public DateTime Date { get; set; }

        public string Pastry { get; set; }
    }
}