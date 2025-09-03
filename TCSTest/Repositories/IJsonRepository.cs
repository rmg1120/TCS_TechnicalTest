namespace TCSTest.Repositories
{
    public interface IJsonRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default);
        Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<T> AddAsync(T entity, CancellationToken ct = default);
        Task<T?> UpdateAsync(Guid id, T entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
