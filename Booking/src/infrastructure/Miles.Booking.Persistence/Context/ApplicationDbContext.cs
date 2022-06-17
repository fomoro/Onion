using Microsoft.EntityFrameworkCore;
using Miles.Booking.Domain.Entities;

namespace Miles.Booking.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}