using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Application.Models.Requests.Empresa
{
    public class EmpresaCreateRequest
    {
        [Required(ErrorMessage = "Nome Fantasia é obrigatório.")]
        [RegularExpression(pattern: "^[A-Za-zÀ-Üà-ü\\s]{6,150}$",
           ErrorMessage = "Informe um nome fantasia válido de 6 a 150 caracteres.")]
        public string? NomeFantasia { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a razão social.")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "Cnpj é obrigatório.")]
        public string? Cnpj { get; set; }
    }
}
