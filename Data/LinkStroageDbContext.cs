using LinkStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkStorage.Data
{
    public class LinkStroageDbContext : DbContext
    {
        public LinkStroageDbContext(DbContextOptions<LinkStroageDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Links> Links { get; set; }
        
    }

  

}
