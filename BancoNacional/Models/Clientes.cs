using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoNacional.Models
{
    [Table("CLIENTES")]
    public class Clientes
    {
        public Clientes(){}

        ///<summary>
        /// Chave primária da tabela CLIENTES
        /// </summary>
        [Key]
        [Required]
        public int CODIGO_CLIENTE { get; set; }

        [ForeignKey("CODIGO_AGENCIA")]
        [Required]
        public int CODIGO_AGENCIA { get; set; }

        [Required]
        public int TIPO_CONTA { get; set; }

        [Required]
        public string NOME { get; set; }

        [Required]
        public int SALDO { get; set; }

    }
}
