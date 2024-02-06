using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Models.Responses
{
    public class EmpresaResponse
    {
        public Guid? IdEmpresa { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
    }
}
