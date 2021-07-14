using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApp.Api.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { 
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(new Department
            { DepartmentID = 1, Name = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department
            { DepartmentID = 2, Name = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department
            { DepartmentID = 3, Name = "Admin" });
            modelBuilder.Entity<Department>().HasData(new Department
            { DepartmentID = 4, Name = "Management" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 1,
                FirstName = "Andrea",
                LastName = "Johnson",
                Email = "andrea@gmail.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Female,
                DepartmentID = 1,
                PhotoPath = "images/andrea.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 2,
                FirstName = "Tommy",
                LastName = "Tom",
                Email = "tom@gmail.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Male,
                DepartmentID = 2,
                PhotoPath = "images/tom.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 3,
                FirstName = "Niko",
                LastName = "Devis",
                Email = "niko@gmail.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Male,
                DepartmentID = 3,
                PhotoPath = "images/niko.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 4,
                FirstName = "Alex",
                LastName = "Greg",
                Email = "alex@gmail.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Female,
                DepartmentID = 3,
                PhotoPath = "images/alex.jpg"
            });
        }
    }
}
