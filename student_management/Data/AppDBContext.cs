using Microsoft.EntityFrameworkCore;
using student_management.Models;

namespace student_management.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options) { 
        
        }
        public DbSet<Student_Management> student_Managements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
