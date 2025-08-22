using Microsoft.EntityFrameworkCore;
using FARSbe.Models;

namespace FARSbe.Data
{
    public class FarsDbContext : DbContext
    {
        public FarsDbContext(DbContextOptions<FarsDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<FARSbe.Models.Attendance> Attendances { get; set; }
    }
}