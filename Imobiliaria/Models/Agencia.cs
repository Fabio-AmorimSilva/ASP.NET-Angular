using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imobiliaria.Models
{
    [Table("Agencias")]
    public class Agencia
    {
        #region Constructor
        public Agencia()
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
        /// Nome da agência (em formato UTF8)
        ///</summary>
        public string Nome { get; set; }

        ///<summary>
        /// Cidade onde a agência está localizada ( em formato UTF8)
        ///</summary>
        public string Cidade { get; set; }

        ///<summary>
        /// Id do corretor da agência
        /// </summary>
        public int idCorretor { get; set; }

        ///<summary>
        /// Id do imovel da agência
        ///</summary>
        public int idImovel { get; set; }

        #endregion

    }
}
