using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassMatchAPI.Models
{
    public partial class ClassMatchContext : DbContext
    {
        public ClassMatchContext()
        {
        }

        public ClassMatchContext(DbContextOptions<ClassMatchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCourse> UserCourse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Jonathan-PC\\JONATHANSQL;Database=ClassMatch;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<UserCourse>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasColumnName("CourseID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Teacher)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Term)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
