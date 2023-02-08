using CodingChallengeV1.DAL.Repository.Abstraction;
using CodingChallengeV1.Shared.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodingChallengeV1.Server.Controllers
{
    /*
     * 
     * referenes:
     * 1. https://www.c-sharpcorner.com/blogs/create-a-net-6-app-on-blazor-wasm-for-crud-operations-with-ef-core
     * 
     */

    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindowRepository _windowRepository;

        public WindowController(IWindowRepository windowRepository)
        {
            _windowRepository = windowRepository;
        }

        [HttpGet]
        public async Task<List<Window>> GetAll()
        {
            return await _windowRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Window> Get(int id)
        {
            return await _windowRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Window> AddWindow([FromBody] Window window)
        {
            return await _windowRepository.CreateAsync(window);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteWindow(int id)
        {
            await _windowRepository.DeleteAsync(id);
            return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateWindow(int id, [FromBody] Window Object)
        {
            if (Object == null)
            {
                return false;
            }
            var existingData = await _windowRepository.GetByIdAsync(id);
            existingData.SubElements = Object.SubElements;
            existingData.TotalSubElements = Object.TotalSubElements;
            existingData.QuantityOfWindows = Object.QuantityOfWindows;
            existingData.Name = Object.Name;
            await _windowRepository.UpdateAsync(existingData);
            return true;
        }
    }
}
