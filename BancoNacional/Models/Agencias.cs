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
        public int Id { get; set; }

       
        public string NOME { get; set; }
         
       
        public string LOCALIZACAO { get; set; }

       
        public int NUMERO_CLIENTES { get; set; }

        public int GerenteId { get; set; }

    }

}
