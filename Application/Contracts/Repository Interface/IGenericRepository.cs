namespace Domain.Repository_Interface;

public interface IGenericRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> GetByIdAsync(string id);
}
