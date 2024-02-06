using ApiEmpresas.Application.Interfaces;
using ApiEmpresas.Application.Models.Requests.Funcionario;
using ApiEmpresas.Application.Models.Responses;
using ApiEmpresas.Domain.Entities;
using ApiEmpresas.Domain.Interfaces.Services;
using ApiEmpresas.Domain.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Services
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IFuncionarioDomainService _funcionarioDomainService;
        private readonly IMapper _mapper;
        private readonly IEmpresaDomainService _empresaDomainService;

        public FuncionarioAppService(IFuncionarioDomainService funcionarioDomainService, IMapper mapper, IEmpresaDomainService empresaDomainService)
        {
            _funcionarioDomainService = funcionarioDomainService;
            _mapper = mapper;
            _empresaDomainService = empresaDomainService;
        }

        public FuncionarioResponse Create(FuncionarioCreateRequest request)
        {
            var funcionario = _mapper.Map<Funcionario>(request);
            _funcionarioDomainService.Create(funcionario);

            funcionario.Empresa = _empresaDomainService.GetById(funcionario.IdEmpresa);
            return _mapper.Map<FuncionarioResponse>(funcionario);

        }

        public FuncionarioResponse Update(FuncionarioUpdateRequest request)
        {
            var funcionario = _funcionarioDomainService.GetById(request.IdFuncionario);

            if (funcionario != null)
            {
                
                funcionario.Nome = request.Nome;
                funcionario.Cpf = request.Cpf;
                funcionario.Matricula = request.Matricula;
                funcionario.IdEmpresa = (Guid)request.IdEmpresa;

               
                _funcionarioDomainService.Update(funcionario); 

               
            }
            return _mapper.Map<FuncionarioResponse>(funcionario);
        }

            public FuncionarioResponse Delete(Guid id)
            {

            var funcionario = _funcionarioDomainService.GetById(id);

            funcionario.Empresa = _empresaDomainService.GetById(funcionario.IdEmpresa);

            _funcionarioDomainService.Delete(id);

            return _mapper.Map<FuncionarioResponse>(funcionario);


            }

        public List<FuncionarioResponse> GetAll()
        {
            var funcionario = _funcionarioDomainService.GetAll();
            var funcionarioResponse = funcionario.Select(f => new FuncionarioResponse 
            { 
                IdFuncionario = (Guid)f.IdFuncionario,
                Nome = f.Nome,
                Cpf = f.Cpf,
                Matricula = f.Matricula,
                DataAdmissao = f.DataAdmissao,
                Empresa = new EmpresaResponse
                {
                    IdEmpresa = f.Empresa.IdEmpresa,
                    NomeFantasia = f.Empresa.NomeFantasia,
                    RazaoSocial = f.Empresa.RazaoSocial,
                    Cnpj = f.Empresa.Cnpj

                }

            }).ToList();

            return funcionarioResponse;

        }

        public FuncionarioResponse GetById(Guid id)
        {
            var funcionario = _funcionarioDomainService.GetById(id);
            return _mapper.Map<FuncionarioResponse>(funcionario);
        }
    }
}
