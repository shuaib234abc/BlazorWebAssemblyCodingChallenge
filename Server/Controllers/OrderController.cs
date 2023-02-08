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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<List<Order>> GetAll()
        {
            return await _orderRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Order> AddOrder([FromBody] Order order)
        {
            return await _orderRepository.CreateAsync(order);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteOrder(int id)
        {
            await _orderRepository.DeleteAsync(id);
            return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateOrder(int id, [FromBody] Order Object)
        {
            if (Object == null)
            {
                return false;
            }
            var existingData = await _orderRepository.GetByIdAsync(id);
            existingData.State = Object.State;
            existingData.Windows = Object.Windows;
            existingData.Name = Object.Name;
            await _orderRepository.UpdateAsync(existingData);
            return true;
        }
    }
}
