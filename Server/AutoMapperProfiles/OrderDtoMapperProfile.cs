using AutoMapper;
using CodingChallengeV1.DTO;
using CodingChallengeV1.Entity.Models;

/*
 * 
 * references:
 * 1. Using AutoMapper
 *      https://medium.com/dotnet-hub/use-automapper-in-asp-net-or-asp-net-core-automapper-getting-started-introduction-dotnet-9cdda3db1feb
 * 
 */

namespace CodingChallengeV1.Server.AutoMapperConfigs
{
    public class OrderDtoMapperProfile : Profile
    {
        public OrderDtoMapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Window, WindowDto>();
            CreateMap<WindowDto, Window>();
            CreateMap<SubElement, SubElementDto>();
            CreateMap<SubElementDto, SubElement>();
        }
    }
}
