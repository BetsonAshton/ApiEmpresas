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
    public class FuncionarioDomainService:IFuncionarioDomainService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEmpresaRepository _empresaRepository;


        public FuncionarioDomainService(IFuncionarioRepository funcionarioRepository, IEmpresaRepository empresaRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _empresaRepository = empresaRepository;
        }

        public void Create(Funcionario entity)
        {
            #region Regra: Não podem exitir funcionários com o mesmo CPF

            if (_funcionarioRepository.Get(f => f.Cpf.Equals(entity.Cpf)) != null)
                throw new ArgumentException("O CPF informado já está cadastrado no sistema, tente outro.");

            #endregion

             #region Regra: Não podem exitir funcionários com a mesma Matrícula

            if (_funcionarioRepository.Get(f => f.Matricula.Equals(entity.Matricula)) != null)
                throw new ArgumentException("A Matrícula informada já está cadastrada no sistema, tente outra.");

            #endregion

            #region Regra: A Empresa deve existir no sistema

            // Verifica se a empresa existe antes de prosseguir com a operação
            if (_empresaRepository.GetById(entity.IdEmpresa) == null)
            {
                throw new ArgumentException("A Empresa informada não foi encontrada, verifique o ID.");
            }


            #endregion
            _funcionarioRepository.Create(entity);
        }

        public void Update(Funcionario entity)
        {

            #region Regra: O Funcionário deve existir no sistema

            if (_funcionarioRepository.GetById((Guid)entity.IdFuncionario) == null)
            {
                throw new ArgumentException("Funcionário não foi encontrado, verifique o ID.");
            }

            #endregion

            #region Regra: Não podem exitir funcionários com o mesmo CPF

            if (_funcionarioRepository.Get(f => f.Cpf.Equals(entity.Cpf) && f.IdFuncionario != entity.IdFuncionario) != null)
                throw new ArgumentException("O CPF informado já está cadastrado para outro funcionário no sistema.");

            #endregion

            #region Regra: Não podem exitir funcionários com a mesma Matrícula

            if (_funcionarioRepository.Get(f => f.Matricula.Equals(entity.Matricula) && f.IdFuncionario != entity.IdFuncionario) != null)
                throw new ArgumentException("A Matrícula informada já está cadastrada para outro funcionário no sistema.");

            #endregion

            #region Regra: A Empresa deve existir no sistema

            if (_empresaRepository.GetById(entity.IdEmpresa) == null)
            {
                throw new ArgumentException("A Empresa informada não foi encontrada, verifique o ID.");
            }

            #endregion

            _funcionarioRepository.Update(entity);
        }

        public void Delete(Guid id)
        {
            #region Regra: O Funcionário deve existir no sistema

            if (_funcionarioRepository.GetById(id) == null)
                throw new ArgumentException("O funcionario informado não foi encontrado, verifique o ID.");

            #endregion


            var funcionario = _funcionarioRepository.GetById(id);
            _funcionarioRepository.Delete(funcionario);
        }

        public List<Funcionario> GetAll()
        {
           return _funcionarioRepository.GetAll();
        }

        public Funcionario GetById(Guid id)
        {
            return _funcionarioRepository.GetById(id);

        }
    }
}
