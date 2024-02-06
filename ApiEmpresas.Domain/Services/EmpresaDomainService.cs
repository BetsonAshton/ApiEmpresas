using ApiEmpresas.Domain.Entities;
using ApiEmpresas.Domain.Interfaces.Repositories;
using ApiEmpresas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Domain.Services
{
    public class EmpresaDomainService: IEmpresaDomainService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public EmpresaDomainService(IEmpresaRepository empresaRepository, IFuncionarioRepository funcionarioRepository)
        {
            _empresaRepository = empresaRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public void Create(Empresa entity)
        {
            #region Regra: Não podem exitir empresas com a mesma razão social

            if (_empresaRepository.Get(e => e.RazaoSocial.Equals(entity.RazaoSocial)) != null)
                throw new ArgumentException("A Razão social informada já está cadastrado no sistema, tente outro.");

            #endregion

            #region Regra: Não podem existir empresas com o mesmo CNPJ

            if (_empresaRepository.Get(e => e.Cnpj.Equals(entity.Cnpj)) != null)
                throw new ArgumentException("O CNPJ informado já está cadastrado no sistema, tente outro.");

            #endregion

            _empresaRepository.Create(entity);

        }

        public void Update(Empresa entity)
        {
            #region Regra: A Empresa deve existir no sistema

            if (_empresaRepository.GetById((Guid)entity.IdEmpresa) == null)
            {
                throw new ArgumentException("A Empresa informada não foi encontrada, verifique o ID.");
            }

            #endregion

            #region Regra: Não podem exitir empresas com a mesma razão social

            if (_empresaRepository.Get(e => e.RazaoSocial.Equals(entity.RazaoSocial) && e.IdEmpresa != entity.IdEmpresa) != null)
                throw new ArgumentException("A Razão social informada já está cadastrado para outra empresa no sistema.");

            #endregion

            #region Regra: Não podem existir empresas com o mesmo CNPJ

            if (_empresaRepository.Get(e => e.Cnpj.Equals(entity.Cnpj) && e.IdEmpresa != entity.IdEmpresa) != null)
                throw new ArgumentException("O CNPJ informado já está cadastrado para outra empresa no sistema.");

            #endregion
            _empresaRepository.Update(entity);
        }

        public void Delete(Guid id)
        {
            #region Regra: A Empresa deve existir no sistema

            if (_empresaRepository.GetById(id) == null)
                throw new ArgumentException("A Empresa informada não foi encontrada, verifique o ID.");

            #endregion

            #region Regra: A Empresa não deve conter funcionários

            if (_funcionarioRepository.Count(f => f.IdEmpresa.Equals(id)) > 0)
                throw new ArgumentException("A Empresa não pode ser excluída pois possui funcionários relacionados.");

            #endregion



            var empresa = _empresaRepository.GetById(id);
            _empresaRepository.Delete(empresa);
        }

        public List<Empresa> GetAll()
        {
            return _empresaRepository.GetAll();
        }

        public Empresa GetById(Guid id)
        {
            return _empresaRepository.GetById(id);
        }
    }
}
