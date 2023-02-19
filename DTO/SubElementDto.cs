using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.DTO
{
    public class SubElementDto
    {
        public int Element { get; set; }
        public int Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string TypeAsString { get
            {
                if (Type == 0) return "Undefined";
                else if (Type == 1) return "Doors";
                else if (Type == 2) return "Window";
                else return "";
            }
        }
    }
}
