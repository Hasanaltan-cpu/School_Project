using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Web_Layer.Models.DTOs
{
    public class Login
    {
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
        
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.MultilineText)]
            public int StudentNumber { get; set; }


            public string ReturnUrl { get; set; }
        
    }
}
