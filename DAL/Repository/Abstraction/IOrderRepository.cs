using CodingChallengeV1.Shared.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.DAL.Repository.Abstraction
{
    /*
     * 
     * 1. https://www.c-sharpcorner.com/blogs/create-a-net-6-app-on-blazor-wasm-for-crud-operations-with-ef-core
     * 
     */

    public interface IOrderRepository : IGenericRepository<Order>
    {
        new Task<Order> CreateAsync(Order _object);
        new Task UpdateAsync(Order _object);
        new Task<List<Order>> GetAllAsync();
        new Task<Order> GetByIdAsync(int Id);
        new Task DeleteAsync(int id);
    }
}
