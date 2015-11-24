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

        [Required(ErrorMessage="Pastry can not be null.")]
        [MinLength(1,ErrorMessage = "Pastry need to be atleast 1 character long.")]
        [MaxLength(30,ErrorMessage="Pastry name can not be more then 30 characters.")]
        public string Pastry
        {
            get 
            {
                return _pastry;
            }
            set
            {
                _pastry = value;
            }
        }

        public int Id { get; set; }
    }
}