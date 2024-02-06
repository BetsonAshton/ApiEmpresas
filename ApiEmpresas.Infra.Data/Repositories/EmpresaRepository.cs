using ApiEmpresas.Domain.Entities;
using ApiEmpresas.Domain.Interfaces.Repositories;
using ApiEmpresas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public void Create(Empresa entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Empresas.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(Empresa entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public void Delete(Empresa entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Empresas.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Empresa> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Empresas
                    .OrderBy(e => e.NomeFantasia)
                    .ToList();
            }
        }

        public Empresa GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Empresas
                    .Where(e => e.IdEmpresa == id)
                    .FirstOrDefault();
            }
        }

        public Empresa Get(Func<Empresa, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Empresas
                    .AsNoTracking()
                    .FirstOrDefault(where);
            }
        }

        public int Count(Func<Empresa, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Empresas
                   .Count(where);
            }
        }
    }
}
