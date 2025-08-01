﻿using System.ComponentModel.DataAnnotations;

namespace StackTrack.Models
{
    public class User
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
   
    }
}
