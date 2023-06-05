using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lastadmissionproject.Models
{
    public class Login
    {
        [Key] //primary key
        public string Email { get; set; }

        public string Password { get; set; }

        //assign roles
        public string UserRole { get; set; }

    }
}