using Microsoft.AspNetCore.Identity;
using SMS_Entity_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Entity_Layer.Entities.Concrete
{
    public class AppUser : IdentityUser, IBaseEntity
    
    {
       
        public string Occupation { get; set; } 


        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get; set; }
       
    
    }


}


