using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS_Entity_Layer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Data_Layer.SeedData
{
    public class SeedPages : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasData(
                new Page { Id = 1, Title = "Home", Content = "Home Page", Slug = "home-page", Sorting = 100 },
                new Page { Id = 2, Title = "About Us", Content = "About Us Page", Slug = "about-page", Sorting = 100 },
                new Page { Id = 3, Title = "Services", Content = "Services Page", Slug = "service-page", Sorting = 100 },
                new Page { Id = 4, Title = "Contact Us", Content = "Conctact Us Page", Slug = "contact-page", Sorting = 100 },
                new Page { Id = 5, Title = "Exam Results", Content = "Results of Exams Page", Slug = "results-page", Sorting = 100 });
        }
    }
}
