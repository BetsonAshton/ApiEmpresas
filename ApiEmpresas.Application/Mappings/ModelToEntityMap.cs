using ApiEmpresas.Application.Models.Requests.Empresa;
using ApiEmpresas.Application.Models.Requests.Funcionario;
using ApiEmpresas.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Mappings
{
    public class ModelToEntityMap:Profile
    {
        public ModelToEntityMap() 
        {
            CreateMap<EmpresaCreateRequest, Empresa>()
               .AfterMap((src, dest) =>
               {
                   dest.IdEmpresa = Guid.NewGuid();
               });

            CreateMap<EmpresaUpdateRequest, Empresa>();



           

            CreateMap<FuncionarioCreateRequest, Funcionario>()
                .AfterMap((src, dest) =>
                {
                    dest.IdFuncionario = Guid.NewGuid();
                    dest.DataAdmissao = DateTime.Now;
                });

            CreateMap<FuncionarioUpdateRequest, Funcionario>();


        }
    }
}
