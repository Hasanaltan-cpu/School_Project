using SMS_Entity_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Entity_Layer.Entities
{
    public interface IBaseEntity
    {

        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
        DateTime? DeleteDate { get; set; }
        Status Status { get; set; }

    }
}
