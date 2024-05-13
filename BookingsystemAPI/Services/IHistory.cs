namespace BookingsystemAPI.Services
{
    public interface IHistory<T>
    {
        Task<ICollection<T>> GetAsync(int id);
    }
}
