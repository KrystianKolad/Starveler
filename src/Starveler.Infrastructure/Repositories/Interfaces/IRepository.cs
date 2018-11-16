using System.Collections.Generic;
using System.Threading.Tasks;
using Starveler.Common.Entities;

namespace Starveler.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : BasicEntity
    {
        Task Add(T entity);
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
    }
}