using BookingsystemModels;
using Microsoft.EntityFrameworkCore;

namespace BookingsystemAPI.Data
{
    public class BookingsystemDbContext : DbContext
    {
        public BookingsystemDbContext(DbContextOptions<BookingsystemDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

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
        }
    }
}
