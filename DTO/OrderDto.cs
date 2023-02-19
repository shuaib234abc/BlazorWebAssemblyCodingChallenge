using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.DTO
{
    public class OrderDto
    {
        public string Name { get; set; } = "";
        public string State { get; set; } = "";
        public List<WindowDto> Windows { get; set; } = new List<WindowDto>();
    }
}
