using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imobiliaria.Models
{
    [Table("Corretores")]
    public class Corretor
    {
        #region Constructor
        public Corretor()
        {

        }
        #endregion

        #region Properties
        ///<summary>
        /// A chave única id e a chave primária
        ///</summary>
        [Key]
        [Required]
        public int Id { get; set; }

        ///<summary>
        /// Id da agência a qual o corretor pertence
        ///</summary>
        public int IdAgencia { get; set; }

        ///<summary>
        /// Nome do corretor
        ///</summary>
        public string Nome { get; set; }

        ///<summary>
        /// Idade do corretor
        ///</summary>
        public int Idade { get; set; }

        ///<summary>
        /// Número de vendas do corretor
        ///</summary>
        public int Vendas { get; set; }

        #endregion
    }
}
