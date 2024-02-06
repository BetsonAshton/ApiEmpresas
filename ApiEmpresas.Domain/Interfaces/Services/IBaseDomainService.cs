using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);

        List<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
