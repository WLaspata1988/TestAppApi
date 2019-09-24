using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppApi.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public static ApiDbContext Create(DbContextOptions<ApiDbContext> options)
        {
            return new ApiDbContext(options);
        }

        public DbSet<Players> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
