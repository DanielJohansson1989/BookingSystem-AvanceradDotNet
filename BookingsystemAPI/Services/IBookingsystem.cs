namespace BookingsystemAPI.Services
{
    public interface IBookingsystem<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
