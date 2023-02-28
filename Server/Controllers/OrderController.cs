using AutoMapper;
using CodingChallengeV1.DAL.Repository.Abstraction;
using CodingChallengeV1.DTO;
using CodingChallengeV1.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodingChallengeV1.Server.Controllers
{
    /*
     * 
     * referenes:
     * 1. https://www.c-sharpcorner.com/blogs/create-a-net-6-app-on-blazor-wasm-for-crud-operations-with-ef-core
     * 2. Using AutoMapper: https://medium.com/dotnet-hub/use-automapper-in-asp-net-or-asp-net-core-automapper-getting-started-introduction-dotnet-9cdda3db1feb
     */

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Order>> GetAll()
        {
            return await _orderRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            Order order = await _orderRepository.GetByIdAsync(id);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        [HttpPost]
        public async Task<Order> AddOrder([FromBody] OrderDto order)
        {
            Order orderObjToSave = _mapper.Map<Order>(order);
            return await _orderRepository.CreateAsync(orderObjToSave);
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
            try
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
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
