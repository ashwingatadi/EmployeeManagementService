using Microsoft.EntityFrameworkCore;
using System;

#nullable disable

namespace EmployeeService.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(false);
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(2)
                    .IsFixedLength(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(false);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Department");

                entity.HasOne(d => d.EmploymentType)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmploymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_EmploymentTypes");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Grade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Designations");
            });

            modelBuilder.Entity<EmploymentType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(false);
            });

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Technical"
                },
                new Department
                {
                    Id = 2,
                    Name = "Human Resources"
                },
                new Department
                {
                    Id = 3,
                    Name = "Finance"
                }, new Department
                {
                    Id = 4,
                    Name = "Admin"
                },
                new Department
                {
                    Id = 5,
                    Name = "Help Desk"
                }
            );

            modelBuilder.Entity<Designation>().HasData(
                new Designation
                {
                    Id = "A",
                    Name = "CEO"
                },
                new Designation
                {
                    Id = "B",
                    Name = "CTO"
                },
                new Designation
                {
                    Id = "C",
                    Name = "Delivery Manager"
                },
                new Designation
                {
                    Id = "D",
                    Name = "Manager"
                },
                new Designation
                {
                    Id = "E",
                    Name = "Lead"
                },
                new Designation
                {
                    Id = "F",
                    Name = "Senior Engineer"
                },
                new Designation
                {
                    Id = "G",
                    Name = "Engineer"
                },
                new Designation
                {
                    Id = "H",
                    Name = "Junior Engineer"
                }
            );

            modelBuilder.Entity<EmploymentType>().HasData(
                new EmploymentType
                {
                    Id = 1,
                    Type = "Permanent"
                },
                new EmploymentType
                {
                    Id = 2,
                    Type = "Contract"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Ashwin",
                    LastName = "Gatadi",
                    DateOfBirth = new DateTime(1990, 09, 17),
                    DepartmentId = 1,
                    EmploymentTypeId = 1,
                    Grade = "E"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Aditya",
                    LastName = "Kiran",
                    DateOfBirth = new DateTime(1987, 07, 30),
                    DepartmentId = 2,
                    EmploymentTypeId = 2,
                    Grade = "D"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Shalini",
                    LastName = "Hazari",
                    DateOfBirth = new DateTime(1993, 02, 12),
                    DepartmentId = 3,
                    EmploymentTypeId = 1,
                    Grade = "D"
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Sheetal",
                    LastName = "Bhosale",
                    DateOfBirth = new DateTime(1986, 12, 12),
                    DepartmentId = 3,
                    EmploymentTypeId = 1,
                    Grade = "G"
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Kaustubh",
                    LastName = "Kulkarni",
                    DateOfBirth = new DateTime(1977, 07, 03),
                    DepartmentId = 1,
                    EmploymentTypeId = 1,
                    Grade = "C"
                });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
