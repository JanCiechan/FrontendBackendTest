using FactoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryAPI.Data
{
    public class ItemDbContext:DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) :base(options) { }
        public DbSet<Item> Items { get; set; }
    }
    
}
