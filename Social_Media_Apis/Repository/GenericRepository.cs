using Core.Entities;
using Core.Repositories;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext dbContext;

        public GenericRepository(SocialMediaContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(T item)
        {
            await dbContext.Set<T>().AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
            {
                throw new Exception("Item not found.");
            }

            dbContext.Set<T>().Remove(item);
            await dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
           
            return await dbContext.Set<T>().ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await SpecificationEval<T>.GetQuery(dbContext.Set<T>(), spec).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await SpecificationEval<T>.GetQuery(dbContext.Set<T>(), spec).FirstOrDefaultAsync();
        }



        public async Task UpdateAsync(int id, T updatedItem)
            {
                var existingItem = await GetByIdAsync(id);
                if (existingItem == null)
                {
                    throw new Exception("Item not found.");
                }

                // Optionally: Copy properties from updatedItem to existingItem
                // This assumes T has a method for copying or updating properties
                // You can use reflection or a library like AutoMapper to copy properties
                // Example using reflection:
                foreach (var property in typeof(T).GetProperties())
                {
                    if (property.CanWrite)
                    {
                        var value = property.GetValue(updatedItem);
                        property.SetValue(existingItem, value);
                    }
                }

                dbContext.Set<T>().Update(existingItem);
                await dbContext.SaveChangesAsync();
            

        }
    }
}
