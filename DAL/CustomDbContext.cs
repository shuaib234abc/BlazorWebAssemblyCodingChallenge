using CodingChallengeV1.Shared.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeV1.DAL
{
    /*
     * 
     * references:
     * 1.   getting started with Entity Framework Core - Code first:
     *              https://www.c-sharpcorner.com/article/using-entity-framework-core/
     * 
     */

    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<SubElement> SubElements { get; set; }
        public DbSet<Window> Windows { get; set; }
    }
}
