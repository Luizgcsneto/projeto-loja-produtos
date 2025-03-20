using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Notifications;

namespace Entities.Entities
{
    [Table("TB_PRODUTO")]
    public class Produto : Notifies
    {
      
        [Column("PRD_ID")]
        [Display(Name = "Código")]
        public int Id
        {
            get;
            set;
        }

        [Column("PRD_NOME")]
        [MaxLength(255)]
        [Display(Name = "Nome")]
        public string Nome
        {
            get; 
            set;
        }

        [Column("PRD_DESCRICAO")]
        [MaxLength(150)]
        [Display(Name = "Descrição")]
        public string Descricao
        {
            get; 
            set; 
        }

        [Column("PRD_QTD_ESTOQUE")]
        [Display(Name = "Quantidade em estoque")]
        public int QtdEstoque
        {
            get; 
            set;
        }

        [Column("PRD_PRECO")]
        [Display(Name = "Preço")]
        public decimal Preco
        {
            get; 
            set; 
        }

        [Column("PRD_ESTADO")]
        [Display(Name = "Estado")]
        public bool? Estado { get; set; }


        [Column("PRD_DATA_CADASTRO")]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("PRD_DATA_ALTERACAO")]
        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }



    }
}
