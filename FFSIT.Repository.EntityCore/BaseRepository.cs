using FFSIT.Model.Entities;
using FFSIT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FFSIT.Repository.EntityCore
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        DbContext Context { get; }

        public BaseRepository(DbContext context)
        {
           Context = context;
        }

        public async Task<T?> GetByIdAsync(long id) => await Context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await Context.Set<T>().ToListAsync();

        public async Task<PaginationResult<T>> GetAllAsync(int page, int quantityPerPage)
        {
            var totalQuantity = await Context.Set<T>().CountAsync();
            var data = await Context.Set<T>().Skip((page - 1) * quantityPerPage).Take(quantityPerPage).ToListAsync();
            return new PaginationResult<T>(data, page, quantityPerPage, totalQuantity);
        }

        public async Task<T> AddAsync(T entity, bool saveChanges = true)
        {
            await Context.Set<T>().AddAsync(entity);
            if (saveChanges)
                await SaveChangeAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity, bool saveChanges = true)
        {
            Context.Set<T>().Update(entity);
            if (saveChanges)
                await SaveChangeAsync();
        }

        public async Task DeleteAsync(T entity, bool saveChanges = true)
        {
            entity.Delete();
            Context.Set<T>().Update(entity);
            if (saveChanges)
                await SaveChangeAsync();
        }

        public async Task DeleteAsync(long id, bool saveChanges = true)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                await DeleteAsync(entity, saveChanges);
        }

        public async Task SaveChangeAsync() => await Context.SaveChangesAsync();
    }
}