using CodingChallengeV1.DAL.Repository.Abstraction;
using CodingChallengeV1.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.DAL.Repository.Implementation
{
    public class WindowRepository : IWindowRepository
    {
        /**
         * 
         * references:
         * 1. https://www.c-sharpcorner.com/blogs/create-a-net-6-app-on-blazor-wasm-for-crud-operations-with-ef-core
         * 2. resolving the issue of simultaneous tracking of one entity by multiple instances
         *          https://stackoverflow.com/questions/48202403/instance-of-entity-type-cannot-be-tracked-because-another-instance-with-same-key
         *          https://stackoverflow.com/questions/12211680/what-difference-does-asnotracking-make
         * 3. cascade delete
         *          https://learn.microsoft.com/en-us/ef/core/saving/cascade-delete
         * 
         */

        CustomDbContext _dbContext;

        public WindowRepository(CustomDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Window> CreateAsync(Window _object)
        {
            var obj = await _dbContext.Windows.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Window _object)
        {
            _dbContext.Windows.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Window>> GetAllAsync()
        {
            return await _dbContext.Windows.AsNoTracking().ToListAsync();
        }

        public async Task<Window> GetByIdAsync(int Id)
        {
            return await _dbContext.Windows.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Windows.Include(x => x.SubElements).FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
