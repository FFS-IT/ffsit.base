using FFSIT.Model.Entities;

namespace FFSIT.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(long id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<PaginationResult<T>> GetAllAsync(int page, int quantityPerPage);

        Task<T> AddAsync(T entity, bool saveChanges = true);

        Task UpdateAsync(T entity, bool saveChanges = true);

        Task DeleteAsync(T entity, bool saveChanges = true);

        Task DeleteAsync(long id, bool saveChanges = true);

        Task SaveChangeAsync();
    }
}
