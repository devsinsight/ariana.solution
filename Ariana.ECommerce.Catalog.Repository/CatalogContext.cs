using Ariana.ECommerce.Catalog.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ariana.ECommerce.Catalog.Repository
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
            
        }

        public DbSet<CatalogItem> CatalogItem { get; set; }
        public DbSet<CatalogBrand> CatalogBrand { get; set; }
        public DbSet<CatalogType> CatalogType { get; set; }
    }
}
