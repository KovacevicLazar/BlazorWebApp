﻿// <auto-generated />
using System;
using BlazorApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorApp.Api.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorApp.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = 1,
                            Name = "IT"
                        },
                        new
                        {
                            DepartmentID = 2,
                            Name = "HR"
                        },
                        new
                        {
                            DepartmentID = 3,
                            Name = "Admin"
                        },
                        new
                        {
                            DepartmentID = 4,
                            Name = "Management"
                        });
                });

            modelBuilder.Entity("BlazorApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            DateOfBirth = new DateTime(2021, 7, 9, 21, 26, 17, 756, DateTimeKind.Local).AddTicks(3755),
                            DepartmentID = 1,
                            Email = "andrea@gmail.com",
                            FirstName = "Andrea",
                            Gender = 1,
                            LastName = "Johnson",
                            PhotoPath = "images/andrea.png"
                        },
                        new
                        {
                            EmployeeID = 2,
                            DateOfBirth = new DateTime(2021, 7, 9, 21, 26, 17, 762, DateTimeKind.Local).AddTicks(3738),
                            DepartmentID = 2,
                            Email = "tom@gmail.com",
                            FirstName = "Tommy",
                            Gender = 1,
                            LastName = "Tom",
                            PhotoPath = "images/tom.jpg"
                        },
                        new
                        {
                            EmployeeID = 3,
                            DateOfBirth = new DateTime(2021, 7, 9, 21, 26, 17, 762, DateTimeKind.Local).AddTicks(4137),
                            DepartmentID = 3,
                            Email = "niko@gmail.com",
                            FirstName = "Niko",
                            Gender = 1,
                            LastName = "Devis",
                            PhotoPath = "images/niko.jpg"
                        },
                        new
                        {
                            EmployeeID = 4,
                            DateOfBirth = new DateTime(2021, 7, 9, 21, 26, 17, 762, DateTimeKind.Local).AddTicks(4216),
                            DepartmentID = 3,
                            Email = "alex@gmail.com",
                            FirstName = "Alex",
                            Gender = 1,
                            LastName = "Greg",
                            PhotoPath = "images/alex.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}