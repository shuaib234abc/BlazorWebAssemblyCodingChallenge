using CodingChallengeV1.Entity.Models;
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

    public interface ISubElementRepository : IGenericRepository<SubElement>
    {
        new Task<SubElement> CreateAsync(SubElement _object);
        new Task UpdateAsync(SubElement _object);
        new Task<List<SubElement>> GetAllAsync();
        new Task<SubElement> GetByIdAsync(int Id);
        new Task DeleteAsync(int id);
    }
}
