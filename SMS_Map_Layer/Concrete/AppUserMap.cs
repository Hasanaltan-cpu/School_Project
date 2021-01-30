using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Map_Layer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Map_Layer.Concrete
{
    public class AppUserMap:BaseMap <AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Occupation).IsRequired(true);
            base.Configure(builder);
        }


    }
}
