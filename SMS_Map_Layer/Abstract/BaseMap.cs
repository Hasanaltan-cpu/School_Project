using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS_Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Map_Layer.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x=>x.CreateDate).IsRequired(true);
            builder.Property(x => x.DeleteDate).IsRequired(false);
            //These 2 rows are false because they are nullable it means it can be null.When u create a first time it doesn't have Update&Delete Date.
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(X => X.Status).IsRequired(true);
        }
    }
}
