using Microsoft.EntityFrameworkCore;

namespace CourseSelection.Models
{
    public partial class CsContext : DbContext
    {
        public CsContext(DbContextOptions<CsContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Code).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Sex).IsRequired().HasMaxLength(1);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Code).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Description).IsRequired(false).HasMaxLength(20);
            });

            //modelBuilder.Entity<Student>().HasData(
            //    new Student { Code ="20250123", Name = "王小明", Sex = "1", Age = 16, Grade = "1" },
            //    new Student { Code = "20250201", Name = "孫小美", Sex = "2", Age = 17, Grade = "2" }
            //    );

            //modelBuilder.Entity<Course>().HasData(
            //    new Course { Code = "A110", Name = "普通物理", Description = "物理", Number = 20, Location = "A棟-01" },
            //    new Course { Code = "B215", Name = "微積分",  Number = 30, Location = "B棟-07" }
            //    );

        }
    }
}
