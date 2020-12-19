using EShop.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EShop.Infrastructure.Data
{
    public class EShopDbContext : IdentityDbContext<IdentityUser>
    {
        public EShopDbContext(DbContextOptions<EShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SetTableNamesAsSingle(builder);

            base.OnModelCreating(builder);
        }

        private static void SetTableNamesAsSingle(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }
    }
}
