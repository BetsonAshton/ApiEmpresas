using ApiEmpresas.Application.Interfaces;
using ApiEmpresas.Application.Models.Requests.Empresa;
using ApiEmpresas.Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApiEmpresas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresasController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmpresaResponse), 201)]
        public IActionResult Post(EmpresaCreateRequest request) 
        {
            return StatusCode(201, new
            {
                mensagem = "Empresa cadastrada com sucesso.",
                empresa = _empresaAppService.Create(request)
            });

        }

        [HttpPut]
        [ProducesResponseType(typeof(EmpresaResponse), 200)]
        public IActionResult Put(EmpresaUpdateRequest request)
        {
            return StatusCode(200, new
            {
                mensagem = "Empresa atualizada com sucesso.",
                empresa = _empresaAppService.Update(request)
            });

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EmpresaResponse), 200)]
        public IActionResult Delete(Guid id) 
        {
            return StatusCode(200, new
            {
                mensagem = "Os dados da empresa foram excluídos como sucesso.",
                empresa = _empresaAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EmpresaResponse>), 200)]
        public IActionResult GetAll()
        {
            return StatusCode(200, _empresaAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmpresaResponse), 200)]
        public IActionResult GetById(Guid id)
        {
            return StatusCode(200, _empresaAppService.GetById(id));
        }
    }
}
