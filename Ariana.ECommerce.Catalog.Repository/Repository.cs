using Ariana.ECommerce.Catalog.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly CatalogContext _dbContext;

        public Repository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Update(int id, T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
