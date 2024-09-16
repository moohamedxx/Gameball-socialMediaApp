using Core.Entities;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        public  Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task CreateAsync(T item);
        public Task UpdateAsync(int id,T updatedItem);
        public Task DeleteAsync(int id);
        #region Dynamic Query
        public Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        public Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);
        #endregion
    }
}
