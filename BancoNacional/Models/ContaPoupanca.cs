using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoNacional.Models
{
    [Table("CONTA_POUPANCA")]
    public class ContaPoupanca
    {

        public ContaPoupanca() { }

        /// <summary>
        /// Chave primária da tabela CONTA_POUPANCA
        /// </summary>
        [Key]
        [Required]
        public int CODIGO_CONTA { get; set; }

        [Required]
        public string DONO { get; set; }


    }
}
