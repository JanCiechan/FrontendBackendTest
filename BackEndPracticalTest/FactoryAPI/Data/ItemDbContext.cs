using FactoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryAPI.Data
{   //here we have a class representing our session with database, thanks to which we will be able to interact with it
    public class ItemDbContext:DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) :base(options) { }
        public DbSet<Item> Items { get; set; }
    }
    
}
