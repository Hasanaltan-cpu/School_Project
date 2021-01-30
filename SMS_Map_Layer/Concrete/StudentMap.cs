using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Map_Layer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Map_Layer.Concrete
{
   public class StudentMap:BaseMap<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StudentName).IsRequired(true);
            builder.Property(x => x.StudentNumber).IsRequired(true);
            builder.Property(x => x.Image).IsRequired(true);

            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.LessonId);

            base.Configure(builder);
            
        }


    }
}
