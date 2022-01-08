using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoNacional.Models
{
    [Table("GERENTES")]
    public class Gerentes
    {
        public Gerentes() { }


        ///<summary>
        /// Chave primária da tabela GERENTES
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Agencia")]
        [Required]
        public int AgenciaId { get; set; }

        [ForeignKey("Gerente")]
        [Required]
        public string NOME { get; set; }

        public virtual Gerentes Gerente { get; set; }

        public virtual Agencias Agencia { get; set; }

    }
}
