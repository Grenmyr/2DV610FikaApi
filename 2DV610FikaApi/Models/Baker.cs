using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;



namespace _2DV610FikaApi.Models
{
    public class Baker
    {
     
        public Baker(string name, string email)
        {
            Name = name;
            Email = email;
        }
    
        [Required(ErrorMessage="Email can not be null.")]
        [MinLength(4,ErrorMessage="Email need to be atleast 4 characters long.")]
        [MaxLength(254,ErrorMessage="Email can not be longer then 254 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name can not be null.")]
        [MinLength(1, ErrorMessage = "Name need to be atleast 1 characters long.")]
        [MaxLength(20, ErrorMessage = "Name can not be longer then 20 characters.")]
        public string Name { get; set; }

        public int Id { get; set; }

    }    
}