using LinkStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkStorage.Data
{
    public class LinkStroageDbContext : DbContext
    {
        public LinkStroageDbContext(DbContextOptions<LinkStroageDbContext> options) : base(options) { }
        
    }

  

}
