using Ariana.ECommerce.Catalog.Domain;
using Ariana.ECommerce.Catalog.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ariana.ECommerce.Catalog.Repository
{
    public class CatalogRepository : Repository<CatalogItem>, ICatalogRepository
    {
        public CatalogRepository(CatalogContext dbContext)
        : base(dbContext)
        {

        }
    }
}
