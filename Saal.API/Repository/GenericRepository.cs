using Microsoft.EntityFrameworkCore;
using Saal.API.Data;
using Saal.API.Models;

namespace Saal.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        /// <summary>
        /// Saal Context to operate with.
        /// </summary>
        public readonly SaalContext context;

        /// <summary>
        /// Set to operate with.
        /// </summary>
        public DbSet<T> baseSet => context.Set<T>();

        /// <summary>
        /// Generic repository constructor.
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(SaalContext saalContext)
        {
            context = saalContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public async void Add(T entity)
        {
            baseSet.Add(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete operation.
        /// </summary>
        /// <param name="entity">entity to delete.</param>
        public async void Delete(T entity)
        {
            baseSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// GetAll operation.
        /// </summary>
        public async Task<IEnumerable<T>> GetAll()
        {
            return await baseSet.ToListAsync<T>();
        }

        /// <summary>
        /// Get by id operation.
        /// </summary>
        /// <param name="id">id of the entity</param>
        /// <returns>entity.</returns>
        public async Task<T> GetById(int id)
        {
            var entity = await context.FindAsync<T>(id);
            return entity;
        }

        /// <summary>
        /// Update operation.
        /// </summary>
        /// <param name="entity">entity to update.</param>
        public async void Update(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
