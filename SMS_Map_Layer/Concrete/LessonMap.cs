using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Map_Layer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Map_Layer.Concrete
{
  public class LessonMap:BaseMap<Lesson>
    {
        public override void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LessonName).HasMaxLength(50).IsRequired(true);
            base.Configure(builder);

        }
    }
}
