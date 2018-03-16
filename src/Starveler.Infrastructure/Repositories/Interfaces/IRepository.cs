using System.Collections.Generic;
using Starveler.Common.Entities;

namespace Starveler.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : BasicEntity
    {
         void Add(T entity);
         IList<T> GetAll();
         T GetById(int id);
    }
}