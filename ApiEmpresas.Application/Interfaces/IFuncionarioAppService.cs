using ApiEmpresas.Application.Models.Requests.Funcionario;
using ApiEmpresas.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Interfaces
{
    public interface IFuncionarioAppService
    {
        FuncionarioResponse Create(FuncionarioCreateRequest request);
        FuncionarioResponse Update(FuncionarioUpdateRequest request);
        FuncionarioResponse Delete(Guid id);

        List<FuncionarioResponse> GetAll();

        FuncionarioResponse GetById(Guid id);

    }
}
