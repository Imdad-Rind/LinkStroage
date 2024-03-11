using LinkStorage.Models;
using Microsoft.EntityFrameworkCore;
using IdentityDbContext = Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;

namespace LinkStorage.Data
{
    public class LinkStorageDbContext : IdentityDbContext
    {
        public LinkStorageDbContext(DbContextOptions<LinkStorageDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Links> Links { get; set; }
        
    }

  

}
