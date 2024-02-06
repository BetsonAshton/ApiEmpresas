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
    public class FuncionarioRepository: IFuncionarioRepository
    {
        public void Create(Funcionario entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Funcionarios.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(Funcionario entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public void Delete(Funcionario entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Funcionarios.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Funcionario> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Funcionarios
                    .Include(f => f.Empresa)
                    .OrderBy(f => f.Nome)
                    .ToList();
            }
        }

        public Funcionario GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Funcionarios
                    .Include(f => f.Empresa)
                    .Where(f => f.IdFuncionario == id)
                    .FirstOrDefault();
            }
        }

        public Funcionario Get(Func<Funcionario, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Funcionarios
                    .AsNoTracking()
                    .FirstOrDefault(where);
            }
        }

        public int Count(Func<Funcionario, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Funcionarios
                   .Count(where);
            }
        }
    }
}
