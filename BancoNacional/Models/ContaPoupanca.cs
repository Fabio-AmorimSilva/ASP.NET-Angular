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
        public int Id { get; set; }

        [ForeignKey("Dono")]
        public int DONO { get; set; }

        public virtual Clientes Dono { get; set; }


    }
}
