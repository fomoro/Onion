using Ardalis.Specification.EntityFrameworkCore;
using Miles.Booking.Persistence.Context;
using Miles.Booking.Repository;

namespace Miles.Booking.Persistence.Repository
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public MyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
