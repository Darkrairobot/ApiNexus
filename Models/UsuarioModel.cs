using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiNexus.Models
{
    public class UsuarioModel
    {

        [Key]
        public Guid id_user { get; set; }

        public string nome { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string senha { get; set; } = string.Empty;

        public string telefone { get; set; } = string.Empty;

        public enum status_
        {
            ativo,
            inativo
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? data_criacao { get; set; }

    }
}
