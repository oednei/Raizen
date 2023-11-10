using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Raizen.WebApp.CadastroClientes.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do cliente.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Data de Nascimento do cliente.")]
        [DataType(DataType.Date, ErrorMessage = "Data de Nascimento informada em formato incorreto.")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Digite o CEP do cliente. Ex: 99999999")]
        public string CEP { get; set; }
    }
}
