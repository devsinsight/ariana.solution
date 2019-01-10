using Ariana.ECommerce.Catalog.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext _dbContext;

        public UnitOfWork(CatalogContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
