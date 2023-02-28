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
    public class SubElementRepository : ISubElementRepository
    {
        /**
         * 
         * references:
         * 1. https://www.c-sharpcorner.com/blogs/create-a-net-6-app-on-blazor-wasm-for-crud-operations-with-ef-core
         * 2. resolving the issue of simultaneous tracking of one entity by multiple instances
         *          https://stackoverflow.com/questions/48202403/instance-of-entity-type-cannot-be-tracked-because-another-instance-with-same-key
         *          https://stackoverflow.com/questions/12211680/what-difference-does-asnotracking-make
         * 
         */

        CustomDbContext _dbContext;

        public SubElementRepository(CustomDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<SubElement> CreateAsync(SubElement _object)
        {
            var obj = await _dbContext.SubElements.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(SubElement _object)
        {
            _dbContext.SubElements.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SubElement>> GetAllAsync()
        {
            return await _dbContext.SubElements.AsNoTracking().ToListAsync();
        }

        public async Task<SubElement> GetByIdAsync(int Id)
        {
            return await _dbContext.SubElements.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.SubElements.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
