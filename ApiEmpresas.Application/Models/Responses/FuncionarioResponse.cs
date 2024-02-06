using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Models.Responses
{
    public class FuncionarioResponse
    {
        
        public Guid IdFuncionario { get; set; }
      
        public string? Nome { get; set; }
      
        public string? Cpf { get; set; }
    
        public string? Matricula { get; set; }
 
        public DateTime? DataAdmissao { get; set; }
  
        public EmpresaResponse? Empresa { get; set; }
    }
}
