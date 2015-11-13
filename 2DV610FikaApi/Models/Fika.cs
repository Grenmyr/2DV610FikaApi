using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2DV610FikaApi.Models
{
    public class Fika
    {

        public Fika()
        {

        }

        public Fika(DateTime date)
        {
            Date = date;
        }
        public DateTime Date { get; set; }
    }
}