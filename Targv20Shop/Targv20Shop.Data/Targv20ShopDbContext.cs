using Microsoft.EntityFrameworkCore;
using Targv20Shop.Core.Domain;

namespace Targv20Shop.Data
{
    public class Targv20ShopDbContext : DbContext
    {
        public Targv20ShopDbContext(DbContextOptions<Targv20ShopDbContext> options)
            : base(options) { }

        public DbSet<Old_Car> Old_Car { get; set; }
        public DbSet<Old_Car> New_Car { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }
    }
}
