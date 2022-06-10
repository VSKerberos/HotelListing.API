using HotelListing.API.Models;

namespace HotelListing.API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<TResult?> GetAsync<TResult>(int? id);
        Task<List<T>> GetAllsync();

        Task<List<TResult>> GetAllsync<TResult>();
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task<T> AddAsync(T entity);

        Task<TResult> AddAsync<TSource, TResult>(TSource source);

        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);

        Task UpdateAsync<TSource>(int id, TSource source);

        Task<bool> Exists(int id);
    }
}
