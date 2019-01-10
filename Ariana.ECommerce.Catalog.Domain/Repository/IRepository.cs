using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Domain.Repository
{
    public interface IRepository<T> where T: class, IEntity
    {
        IQueryable<T> GetAll();

        Task<T> GetById(int id);

        Task Create(T entity);

        void Update(int id, T entity);

        Task Delete(int id);
    }
}
