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
        public int Id { get; set; }

        [ForeignKey("Dono")]
        public int DONO { get; set; }

        public virtual Clientes Dono { get; set; }


    }
}
