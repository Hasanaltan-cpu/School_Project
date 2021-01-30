using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Map_Layer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Map_Layer.Concrete
{
    public class PageMap:BaseMap<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Slug).IsRequired(false);
            builder.Property(x => x.Sorting).IsRequired(false);
            builder.Property(x => x.Content).IsRequired(true);
            base.Configure(builder);

         }


    }
}
