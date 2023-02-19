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
     */

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<Window> Windows { get; set; }

        public Order()
        {
            this.Name = "";
            this.State = "";
            this.Windows = new List<Window>();
        }
    }
}
