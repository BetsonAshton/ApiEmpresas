using ApiEmpresas.Application.Interfaces;
using ApiEmpresas.Application.Models.Requests.Funcionario;
using ApiEmpresas.Application.Models.Responses;
using ApiEmpresas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApiEmpresas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly IEmpresaDomainService _empresaDomainService;


        public FuncionariosController(IFuncionarioAppService funcionarioAppService, IEmpresaDomainService empresaDomainService)
        {
            _funcionarioAppService = funcionarioAppService;
            _empresaDomainService = empresaDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FuncionarioResponse), 201)]
        public IActionResult Post(FuncionarioCreateRequest request)
        {

            return StatusCode(201, new
            {
                mensagem = "Funcionario cadastrado com sucesso.",
                funcionario = _funcionarioAppService.Create(request)
            });

        }

        [HttpPut]
        [ProducesResponseType(typeof(FuncionarioResponse), 200)]
        public IActionResult Put(FuncionarioUpdateRequest request)
        {
            return StatusCode(200, new
            {
                mensagem = "Funcionario atualizado com sucesso.",
                funcionario = _funcionarioAppService.Update(request)
            });

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FuncionarioResponse), 200)]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(201, new
            {
                mensagem = "O seguinte funcionario  foi excluído como sucesso.",
                funcionario = _funcionarioAppService.Delete(id)
            });

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FuncionarioResponse>), 200)]
        public IActionResult GetAll()
        {
            return Ok(_funcionarioAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FuncionarioResponse), 200)]
        public IActionResult GetById(Guid id)
        {
            return Ok(_funcionarioAppService.GetById(id));
        }
    }
}
