using Saal.API.Models;

namespace Saal.API.Repository
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <typeparam name="T">generic entity</typeparam>
    public interface IGenericRepository<T> where T : Base
    {
        /// <summary>
        /// Add operation.
        /// </summary>
        /// <param name="entity">entity to add.</param>
        public Task<T> Add(T entity);

        /// <summary>
        /// Delete operation.
        /// </summary>
        /// <param name="entity">entity to delete.</param>
        public Task Delete(T entity);

        /// <summary>
        /// Update operation.
        /// </summary>
        /// <param name="entity">entity to update.</param>
        public Task<T> Update(T entity);

        /// <summary>
        /// GetAll operation.
        /// </summary>
        public Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Get by id operation.
        /// </summary>
        /// <param name="id">id of the entity</param>
        /// <returns>entity.</returns>
        public Task<T> GetById(int id);
    }
}
