using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiNexus.Models
{
    public class ClienteModel
    {

        [Key]
        public Guid id_cliente { get; set; }
      
        public Guid id_user { get; set; }

        public string nome { get; set; } = string.Empty;

        public string CPF_CNPJ { get; set; } = string.Empty;

        public string tipo { get; set; } = string.Empty;

        public DateTime? dataNascimento { get; set; }

        public string email { get; set; } = string.Empty;

        public string telefone { get; set; } = string.Empty;

        public string endereco { get; set; } = string.Empty;

        public string numero { get; set; } = string.Empty;

        public string? complemento { get; set; } = string.Empty;

        public string bairro { get; set; } = string.Empty;

        public string cidade { get; set; } = string.Empty;

        public string estado { get; set; } = string.Empty;

        public string CEP { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? dataCadastro { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? dataAtualizacao { get; set; }

        public string? status_ { get; set; }

    }
}
