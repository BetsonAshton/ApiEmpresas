using ApiEmpresas.Application.Models.Responses;
using ApiEmpresas.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Mappings
{
    public class EntityToModelMap: Profile
    {
        public EntityToModelMap() 
        {
            CreateMap<Empresa, EmpresaResponse>();
            CreateMap<Funcionario, FuncionarioResponse>();
        }
    }
}
