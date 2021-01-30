using Microsoft.AspNetCore.Identity;
using SMS_Entity_Layer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Web_Layer.Areas.Admin.Models.DTOs
{
    public class RoleEdit
    {


        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> HasRole { get; set; }
        public IEnumerable<AppUser> HasNotRole { get; set; }

        public string RoleName { get; set; }

        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
}
