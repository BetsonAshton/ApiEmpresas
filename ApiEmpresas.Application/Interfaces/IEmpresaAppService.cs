using ApiEmpresas.Application.Models.Requests.Empresa;
using ApiEmpresas.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Interfaces
{
    public interface IEmpresaAppService
    {
        EmpresaResponse Create(EmpresaCreateRequest request);
        EmpresaResponse Update(EmpresaUpdateRequest request);
        EmpresaResponse Delete(Guid id);
        List<EmpresaResponse> GetAll();

        EmpresaResponse GetById(Guid id);

    }
}
