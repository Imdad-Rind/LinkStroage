using LinkStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkStorage.Data
{
    public class LinkStorageDbContext : DbContext
    {
        public LinkStorageDbContext(DbContextOptions<LinkStorageDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Links> Links { get; set; }
        
    }

  

}
