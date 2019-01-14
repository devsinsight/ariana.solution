using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Domain.Repository
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
