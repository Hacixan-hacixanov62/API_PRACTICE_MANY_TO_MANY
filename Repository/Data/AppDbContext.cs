using Domain.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Repository.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
