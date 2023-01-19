using Microsoft.EntityFrameworkCore;
using HeroApi.Models;

namespace HeroApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }


    }
}
