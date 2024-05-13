

using BookingsystemModels;

namespace BookingsystemAPI.Services
{
    public interface IAppointment<T>
    {
        Task<ICollection<T>> GetByCompanyAndDate(int companyId, DateTime startDate, DateTime endDate);
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<ICollection<T>> GetHours(DateTime start, DateTime end, int customerId);
    }
}
