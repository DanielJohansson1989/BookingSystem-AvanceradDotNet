using BookingsystemAPI.Data;
using BookingsystemModels;
using Microsoft.EntityFrameworkCore;

namespace BookingsystemAPI.Services
{
    public class HistoryRepository : IHistory<History>
    {
        private readonly BookingsystemDbContext _dbContext;
        public HistoryRepository(BookingsystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<History>> GetAsync(int id)
        {
            var result = await _dbContext.History.Where(h => h.AppointmentId == id).ToListAsync();
            if (result.Any())
            {
                return result;
            }
            return null;
        }
    }
}
