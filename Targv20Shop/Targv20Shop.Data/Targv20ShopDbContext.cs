using Microsoft.EntityFrameworkCore;
using Targv20Shop.Core.Domain;

namespace Targv20Shop.Data
{
    public class Targv20ShopDbContext : DbContext
    {
        public Targv20ShopDbContext(DbContextOptions<Targv20ShopDbContext> options)
            : base(options) { }

        public DbSet<Car> Car { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }

        // Позволит создать минграцию для таблицы с необходимыми параметрами
        //ToTable для примера
        // гугли DbContext on model creating

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>(entity => {
        //        entity.ToTable("Car");
        //        });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
