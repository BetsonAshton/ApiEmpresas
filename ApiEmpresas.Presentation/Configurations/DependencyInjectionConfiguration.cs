using ApiEmpresas.Application.Interfaces;
using ApiEmpresas.Application.Services;
using ApiEmpresas.Domain.Entities;
using ApiEmpresas.Domain.Interfaces.Repositories;
using ApiEmpresas.Domain.Interfaces.Services;
using ApiEmpresas.Domain.Services;
using ApiEmpresas.Infra.Data.Repositories;

namespace ApiEmpresas.Presentation.Configurations
{
    public  class DependencyInjectionConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            #region Empresas

            builder.Services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
            builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            builder.Services.AddTransient<IEmpresaAppService, EmpresaAppService>();

            #endregion

            #region Funcionários

            builder.Services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();
            builder.Services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            builder.Services.AddTransient<IFuncionarioAppService, FuncionarioAppService>();

            #endregion


        }
    }
}
