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
        public int Id { get; set; }

        [ForeignKey("Agencia")]
        [Required]
        public int AgenciaId { get; set; }

        [Required]
        public int TIPO_CONTA { get; set; }

        [Required]
        public string NOME { get; set; }

        [Required]
        public int SALDO { get; set; }

        public virtual Agencias Agencia { get; set; }

    }
}
