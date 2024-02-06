using ApiEmpresas.Application.Interfaces;
using ApiEmpresas.Application.Models.Requests.Empresa;
using ApiEmpresas.Application.Models.Responses;
using ApiEmpresas.Domain.Entities;
using ApiEmpresas.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Services
{
    public class EmpresaAppService: IEmpresaAppService
    {
        private readonly IEmpresaDomainService _empresaDomainService;
        private readonly IMapper _mapper;

        public EmpresaAppService(IEmpresaDomainService empresaDomainService, IMapper mapper)
        {
            _empresaDomainService = empresaDomainService;
            _mapper = mapper;
        }

        public EmpresaResponse Create(EmpresaCreateRequest request)
        {
            var empresa = _mapper.Map<Empresa>(request);
            _empresaDomainService.Create(empresa);

            return _mapper.Map<EmpresaResponse>(empresa);
        }

        public EmpresaResponse Update(EmpresaUpdateRequest request)
        {
           var empresa =_mapper.Map<Empresa>(request);
            _empresaDomainService.Update(empresa);

            return _mapper.Map<EmpresaResponse>(empresa);

        }

        public EmpresaResponse Delete(Guid id)
        {
            var empresa = _empresaDomainService.GetById(id);
            _empresaDomainService.Delete(id);

            return _mapper.Map<EmpresaResponse>(empresa);
        }

        public List<EmpresaResponse> GetAll()
        {
            var empresa = _empresaDomainService.GetAll();
            return _mapper.Map<List<EmpresaResponse>>(empresa); 
        }

        public EmpresaResponse GetById(Guid id)
        {
            var empresa = _empresaDomainService.GetById(id);
            return _mapper.Map<EmpresaResponse>(empresa);

        }
    }
}
