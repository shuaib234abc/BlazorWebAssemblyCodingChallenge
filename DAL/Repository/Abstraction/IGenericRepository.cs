using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.DAL.Repository.Abstraction
{
    /*
     * 
     * references:
     * 1. https://www.c-sharpcorner.com/blogs/create-a-net-6-app-on-blazor-wasm-for-crud-operations-with-ef-core
     * 
     */

    public interface IGenericRepository<T>
    {
        public Task<T> CreateAsync(T _object);
        public Task UpdateAsync(T _object);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int Id);
        public Task DeleteAsync(int id);
    }
}
