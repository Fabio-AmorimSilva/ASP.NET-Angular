using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imobiliaria.Models
{
    [Table("Donos")]
    public class Dono
    {
        #region Constructor
        public Dono()
        {

        }
        #endregion

        #region Properties
        ///<summary>
        /// A chave única Id e a cheva primária
        ///</summary>
        [Key]
        [Required]
        public int Id { get; set; }

        ///<summary>
        /// Nome do dono
        ///</summary>
        public string Nome { get; set; }

        ///<summary>
        /// Idade do dono
        ///</summary>
        public int Idade { get; set; }

        ///<summary>
        /// cidade do imovél
        ///</summary>
        public string imovel { get; set; }
        
        #endregion
    }
}
