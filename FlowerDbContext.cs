using Microsoft.EntityFrameworkCore;
using Flowers_API.Models;
namespace Flowers_API.Data
{
    public class FlowerDbContext : DbContext
    {
        public FlowerDbContext(DbContextOptions<FlowerDbContext> options) : base(options)
        {

        }
        public DbSet<Flowers> Flowers { get; set; }

    }
}
