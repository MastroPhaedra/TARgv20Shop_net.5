using Microsoft.EntityFrameworkCore;
using Targv20Shop.Core.Domain;

namespace Targv20Shop.Data
{
    public class Targv20ShopDbContext : DbContext
    {
        public Targv20ShopDbContext(DbContextOptions<Targv20ShopDbContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }

        // Позволит создать минграцию для таблицы с необходимыми параметрами
        //ToTable для примера
        // гугли DbContext on model creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.ExistingFilePaths).WithOne(x=>x.Car).OnDelete(DeleteBehavior.Cascade); //модел билдер сам добавит к car Id и сам найдёт необходимое поле │ OneDelete(DeleteBehavior.Cascade) - удаляет строку в бд
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.ExistingFilePaths).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade); //модел билдер сам добавит к Product Id и сам найдёт необходимое поле │ OneDelete(DeleteBehavior.Cascade) - удаляет строку в бд
            });

            modelBuilder.Entity<ExistingFilePath>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
