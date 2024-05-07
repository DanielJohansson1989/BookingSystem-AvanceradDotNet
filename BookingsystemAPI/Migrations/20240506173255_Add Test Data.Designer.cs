﻿// <auto-generated />
using System;
using BookingsystemAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingsystemAPI.Migrations
{
    [DbContext(typeof(BookingsystemDbContext))]
    [Migration("20240506173255_Add Test Data")]
    partial class AddTestData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingsystemModels.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<DateTime>("AppointmentEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Appointment");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            AppointmentEnd = new DateTime(2024, 6, 16, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            AppointmentStart = new DateTime(2024, 6, 16, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            CompanyId = 1,
                            CustomerId = 1
                        },
                        new
                        {
                            AppointmentId = 2,
                            AppointmentEnd = new DateTime(2024, 8, 1, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentStart = new DateTime(2024, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            CompanyId = 1,
                            CustomerId = 1
                        },
                        new
                        {
                            AppointmentId = 3,
                            AppointmentEnd = new DateTime(2024, 8, 21, 6, 59, 0, 0, DateTimeKind.Unspecified),
                            AppointmentStart = new DateTime(2024, 8, 20, 7, 15, 0, 0, DateTimeKind.Unspecified),
                            CompanyId = 1,
                            CustomerId = 1
                        },
                        new
                        {
                            AppointmentId = 4,
                            AppointmentEnd = new DateTime(2024, 5, 19, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentStart = new DateTime(2024, 5, 19, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            CompanyId = 1,
                            CustomerId = 2
                        },
                        new
                        {
                            AppointmentId = 5,
                            AppointmentEnd = new DateTime(2024, 6, 1, 11, 45, 0, 0, DateTimeKind.Unspecified),
                            AppointmentStart = new DateTime(2024, 6, 1, 8, 20, 0, 0, DateTimeKind.Unspecified),
                            CompanyId = 1,
                            CustomerId = 2
                        },
                        new
                        {
                            AppointmentId = 6,
                            AppointmentEnd = new DateTime(2024, 7, 9, 15, 45, 0, 0, DateTimeKind.Unspecified),
                            AppointmentStart = new DateTime(2024, 7, 9, 12, 50, 0, 0, DateTimeKind.Unspecified),
                            CompanyId = 1,
                            CustomerId = 3
                        });
                });

            modelBuilder.Entity("BookingsystemModels.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CompanyName = "Test AB"
                        });
                });

            modelBuilder.Entity("BookingsystemModels.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            EmailAddress = "daniel@johansson.se",
                            FirstName = "Daniel",
                            LastName = "Johansson",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            CustomerId = 2,
                            EmailAddress = "tobias@johansson.se",
                            FirstName = "Tobias",
                            LastName = "Johansson",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            CustomerId = 3,
                            EmailAddress = "markus@johansson.se",
                            FirstName = "Markus",
                            LastName = "Johansson",
                            PhoneNumber = "1234567890"
                        });
                });

            modelBuilder.Entity("BookingsystemModels.Appointment", b =>
                {
                    b.HasOne("BookingsystemModels.Company", "Company")
                        .WithMany("Appointments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingsystemModels.Customer", "Customer")
                        .WithMany("Appointment")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookingsystemModels.Company", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("BookingsystemModels.Customer", b =>
                {
                    b.Navigation("Appointment");
                });
#pragma warning restore 612, 618
        }
    }
}
