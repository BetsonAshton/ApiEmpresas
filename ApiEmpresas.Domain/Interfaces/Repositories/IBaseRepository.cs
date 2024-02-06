using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity Get(Func<TEntity, bool> where);

        int Count(Func<TEntity, bool> where);
        TEntity GetById(Guid id);
    }
}
