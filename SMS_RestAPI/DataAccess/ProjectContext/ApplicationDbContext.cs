using Microsoft.EntityFrameworkCore;
using SMS_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_RestAPI.DataAccess.ProjectContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lesson> Lessons { get; set; }

    }
}
