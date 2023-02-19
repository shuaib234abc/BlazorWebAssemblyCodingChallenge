using CodingChallengeV1.DAL.Repository.Abstraction;
using CodingChallengeV1.Entity.Models;
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
    public class SubElementController : ControllerBase
    {
        private readonly ISubElementRepository _subElementRepository;

        public SubElementController(ISubElementRepository subElementRepository)
        {
            _subElementRepository = subElementRepository;
        }

        [HttpGet]
        public async Task<List<SubElement>> GetAll()
        {
            return await _subElementRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<SubElement> Get(int id)
        {
            return await _subElementRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<SubElement> AddSubElement([FromBody] SubElement subElement)
        {
            return await _subElementRepository.CreateAsync(subElement);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSubElement(int id)
        {
            await _subElementRepository.DeleteAsync(id);
            return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateSubElement(int id, [FromBody] SubElement Object)
        {
            if (Object == null)
            {
                return false;
            }
            var existingData = await _subElementRepository.GetByIdAsync(id);
            existingData.Width = Object.Width;
            existingData.Height = Object.Height;
            existingData.Element = Object.Element;
            existingData.Type = Object.Type;
            await _subElementRepository.UpdateAsync(existingData);
            return true;
        }
    }
}
