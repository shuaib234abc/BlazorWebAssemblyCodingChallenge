using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.DTO
{
    public class WindowDto
    {
        public string Name { get; set; } = "";
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public List<SubElementDto> SubElements { get; set; }

        public WindowDto()
        {
            this.SubElements = new List<SubElementDto>();
        }
    }
}
