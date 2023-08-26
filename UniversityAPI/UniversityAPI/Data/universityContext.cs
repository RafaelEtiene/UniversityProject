using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UniversityAPI.Models;

namespace UniversityAPI.Data
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext()
        {
        }

        public UniversityContext(DbContextOptions<universityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=university;uid=usr_rafiusk;pwd=rafa05", ServerVersion.Parse("8.0.12-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PRIMARY");

                entity.ToTable("course");

                entity.HasIndex(e => e.IdCourse, "idCourse_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCourse)
                    .HasColumnType("int(6)")
                    .HasColumnName("idCourse");

                entity.Property(e => e.IdTeacher)
                    .HasColumnType("int(6)")
                    .HasColumnName("idTeacher");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PRIMARY");

                entity.ToTable("student");

                entity.HasIndex(e => e.IdCourse, "FK_idCourse_idx");

                entity.HasIndex(e => e.IdStudent, "idStudent_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdStudent)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("idStudent");

                entity.Property(e => e.Age)
                    .HasColumnType("int(11)")
                    .HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(45)
                    .HasColumnName("gender");

                entity.Property(e => e.IdCourse)
                    .HasColumnType("int(6)")
                    .HasColumnName("idCourse");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(45)")
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdTeacher)
                    .HasName("PRIMARY");

                entity.ToTable("teacher");

                entity.HasIndex(e => e.IdCourse, "FK_idCourse_idx");

                entity.HasIndex(e => e.IdTeacher, "idTeacher_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTeacher)
                    .HasColumnType("int(6) unsigned")
                    .HasColumnName("idTeacher");

                entity.Property(e => e.Age)
                    .HasMaxLength(45)
                    .HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(45)
                    .HasColumnName("gender");

                entity.Property(e => e.IdCourse)
                    .HasColumnType("int(6)")
                    .HasColumnName("idCourse");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(45)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
