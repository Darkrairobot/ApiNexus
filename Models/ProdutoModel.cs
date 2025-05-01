
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiNexus.Models
{

    public enum status_{
        ativo,

        inativo
    }

    public enum unidadeMedida{
            Kg,
            Mg,

            L,

            Ml,

            un
    }

    public class ProdutoModel
    {
        [Key]
        public Guid id_produto { get; set;}

        public Guid id_user { get; set;}

        public string nome_produto { get; set;} = string.Empty;

        public string descricao { get; set;} = string.Empty;

        public string categoria { get; set;} = string.Empty;

        public int preco { get; set;}

        public int quantidade_estoque {get; set;}

        public unidadeMedida unidade_Medida{ get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? data_cadastro { get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? data_atualizacao { get; set;}

        public status_ status_  {get; set;}

    }

}