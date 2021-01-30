using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMS_Data_Layer.SeedData;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Map_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Data_Layer.ProjectContext
{
   public  class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LessonMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new PageMap());
            builder.ApplyConfiguration(new StudentMap());
            builder.ApplyConfiguration(new SeedPages());
            base.OnModelCreating(builder);
        }


    }
}
