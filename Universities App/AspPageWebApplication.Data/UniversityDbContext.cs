using AspPageWebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
            
        }
        public DbSet<University> Universities { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
