using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.Entity.Models
{
    /*
     * 
     * references:
     * 1. Creating Code first model classes:
     *      https://www.c-sharpcorner.com/article/using-entity-framework-core/
     * 2. C# naming conventions
     *      https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
     * 
     */

    public class SubElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Element { get; set; }
        public SubElementType Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
