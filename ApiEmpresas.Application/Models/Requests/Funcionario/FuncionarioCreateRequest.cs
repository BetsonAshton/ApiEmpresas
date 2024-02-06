using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Models.Requests.Funcionario
{
    public class FuncionarioCreateRequest
    {
        [Required(ErrorMessage = "Nome do Funcionário  é obrigatório.")]
        [RegularExpression(pattern: "^[A-Za-zÀ-Üà-ü\\s]{6,150}$", ErrorMessage = "Informe um nome válido de 6 a 150 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Cpf do funcionário é obrigatório.")]
        public string? Cpf { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a matricula do funcionário.")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "Data de admissão  é obrigatório.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "Id da empresa é obrigatório.")]
        public Guid? IdEmpresa { get; set; }
    }
}
