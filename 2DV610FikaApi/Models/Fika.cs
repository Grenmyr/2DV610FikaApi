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

        public string Pastry 
        {
            get
            {
                return _pastry;
            }
            set 
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _pastry = value;
                }
                
            } 
        }
    }
}