using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoNacional.Models
{
    [Table("CONTA_CORRENTE")]
    public class ContaCorrente
    {

        public ContaCorrente() { }

        /// <summary>
        /// Chave primária da tabela CONTA_CORRENTE
        /// </summary>
        [Key]
        [Required]
        public int CODIGO_CONTA { get; set; }

        [Required]
        public string DONO { get; set; }


    }
}
