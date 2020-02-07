using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimpleAPI.Models
{
    public partial class StudentsLoggerBaseContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public StudentsLoggerBaseContext(DbContextOptions<StudentsLoggerBaseContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Activities> Activities { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<EnrolledIn> EnrolledIn { get; set; }
        public virtual DbSet<StudentData> StudentData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=StudentsLoggerBase; User Id=sa; Password=Borjan3963();");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activities>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Activities_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Activities_Student");
            });

            modelBuilder.Entity<EnrolledIn>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.EnrolledIn)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_EnrolledIn_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.EnrolledIn)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_EnrolledIn_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
