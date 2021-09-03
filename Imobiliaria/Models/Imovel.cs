using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imobiliaria.Models
{
    [Table("Imoveis")]
    public class Imovel
    {
        #region Constructor
        public Imovel()
        {

        }
        #endregion

        #region Properties
        ///<summary>
        /// A chave única Id e a chave primária
        ///</summary>
        [Key]
        [Required]
        public int Id { get; set; }

        ///<summary>
        /// A chave id de dono
        ///</summary>
        public int IdDono { get; set; }

        ///<summary>
        /// A chave id de agência
        ///</summary>
        public int IdAgencia { get; set; }

        ///<summary>
        /// Endereço do imóvel
        ///</summary>
        public string Endereco { get; set; }

        ///<summary>
        /// Preço do imovél
        /// </summary>
        public int Preco { get; set; }
        #endregion
    }
}
