using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoNacional.Models
{

    [Table("AGENCIAS")]
    public class Agencias
    {

        public Agencias() { }

        ///<summary>
        /// Chave primária da tabelas AGENCIAS
        /// </summary>
        
        [Key]
        [Required]
        public int CODIGO_AGENCIA { get; set; }

        [Required]
        public string NOME { get; set; }
         
        [Required]
        public string LOCALIZACAO { get; set; }

        [Required]
        public int NUMERO_CLIENTES { get; set; }

        [ForeignKey("GERENTE")]
        [Required]
        public int GERENTE { get; set; }


    }

}
