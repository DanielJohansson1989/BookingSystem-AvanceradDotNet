using BookingsystemModels;

namespace BookingsystemAPI.Services
{
    public interface ICustomer<T>
    {
        Task<ICollection<T>> GetAll(string sortBy);
        Task<T> GetById(int id);
        /*Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);*/
        Task<ICollection<T>> GetCustomersByDate(DateTime start, DateTime end, string sortBy);
    }
}
