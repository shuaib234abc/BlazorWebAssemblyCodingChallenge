﻿using CodingChallengeV1.DAL.Repository.Abstraction;
using CodingChallengeV1.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.DAL.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        /**
         * 
         * references:
         * 1. https://www.c-sharpcorner.com/blogs/create-a-net-6-app-on-blazor-wasm-for-crud-operations-with-ef-core
         * 2. eager loading of related properties in EF: 
         *          https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager 
         *          https://learn.microsoft.com/en-us/ef/ef6/querying/related-data
         * 
         */

        CustomDbContext _dbContext;

        public OrderRepository(CustomDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Order> CreateAsync(Order _object)
        {
            var obj = await _dbContext.Orders.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Order _object)
        {
            _dbContext.Orders.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.Include(o => o.Windows).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int Id)
        {
            return await _dbContext.Orders
                                    .Where(x => x.Id == Id)
                                    .Include(o => o.Windows)
                                    .ThenInclude(o1 => o1.SubElements)
                                    .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
