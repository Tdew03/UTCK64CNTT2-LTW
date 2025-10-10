using Day08.Models;
using Microsoft.EntityFrameworkCore;

namespace Day08
{
    public class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Kết nối SQL Server
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=CodeFirstDB;Integrated Security=True;TrustServerCertificate=True");

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
