using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoNacional.Models
{
    [Table("GERENTES")]
    public class Gerentes
    {
        public Gerentes() { }

        [Key]
        [Required]
        ///<summary>
        /// Chave primária da tabela GERENTES
        /// </summary>
        public int CODIGO_GERENTE { get; set; }

        [ForeignKey("GERENTES")]
        [Required]
        public int CODIGO_AGENCIA { get; set; }

        [Required]
        public string NOME { get; set; }

    }
}
