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
        public DbSet<Follows> Follows { get; set; }

        /* this is folows class is mapped to user class*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Follows>()
                .HasKey(f => new { f.Follower_Id, f.Following_Id });
            
            builder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithOne(f => f.Following)
                .HasForeignKey(f => f.Following_Id)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<User>()
                .HasMany(u => u.Following)
                .WithOne(f => f.Followers)
                .HasForeignKey(f => f.Follower_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
    }
    
    
  

}
