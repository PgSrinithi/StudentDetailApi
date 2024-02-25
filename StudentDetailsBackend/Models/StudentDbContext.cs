using Microsoft.EntityFrameworkCore;

namespace StudentDetailsBackend.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=database-1.cpeuusyis702.ap-south-1.rds.amazonaws.com; initial Catalog=StudentData; User Id=admin; password=Srinithi17; TrustServerCertificate= True");
        }
    }
}
