using BookingsystemModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingsystemAPI.Data
{
    public class BookingsystemDbContext : IdentityDbContext // För authorization låt klassen ärva IdentityDbContext och Man kan lägga till <IdentityUser> och override ..se video
    {
        public BookingsystemDbContext(DbContextOptions<BookingsystemDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<History> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData( new Customer
            {
                CustomerId = 1,
                FirstName = "Daniel",
                LastName = "Johansson",
                EmailAddress = "daniel@johansson.se",
                PhoneNumber = "1234567890",
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Tobias",
                LastName = "Johansson",
                EmailAddress = "tobias@johansson.se",
                PhoneNumber = "1234567890",
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                FirstName = "Markus",
                LastName = "Johansson",
                EmailAddress = "markus@johansson.se",
                PhoneNumber = "1234567890",
            });

            modelBuilder.Entity<Company>().HasData(new Company 
            { 
                CompanyId = 1,
                CompanyName = "Test AB",
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 1,
                AppointmentStart = new DateTime(2024,06,16,10,00,00),
                AppointmentEnd = new DateTime(2024,06,16,10,30,00),
                CustomerId = 1,
                CompanyId=1,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 2,
                AppointmentStart = new DateTime(2024, 08, 01, 12, 00, 00),
                AppointmentEnd = new DateTime(2024, 08, 01, 13, 00, 00),
                CustomerId = 1,
                CompanyId = 1,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 3,
                AppointmentStart = new DateTime(2024, 08, 20, 07, 15, 00),
                AppointmentEnd = new DateTime(2024, 08, 21, 06, 59, 00),
                CustomerId = 1,
                CompanyId = 1,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 4,
                AppointmentStart = new DateTime(2024, 05, 19, 15, 30, 00),
                AppointmentEnd = new DateTime(2024, 05, 19, 16, 00, 00),
                CustomerId = 2,
                CompanyId = 1,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 5,
                AppointmentStart = new DateTime(2024, 06, 01, 08, 20, 00),
                AppointmentEnd = new DateTime(2024, 06, 01, 11, 45, 00),
                CustomerId = 2,
                CompanyId = 1,
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 6,
                AppointmentStart = new DateTime(2024, 07, 09, 12, 50, 00),
                AppointmentEnd = new DateTime(2024, 07, 09, 15, 45, 00),
                CustomerId = 3,
                CompanyId = 1,
            });
        }
    }
}
