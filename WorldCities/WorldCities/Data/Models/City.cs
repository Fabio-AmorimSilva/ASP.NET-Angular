using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCities.Data.Models
{
    public class City
    {

        #region Constructor
        public City()
        {

        }
        #endregion

        #region Properties
        ///<summary>
        /// The Unique id and primary key for this city
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        ///<summary>
        /// City name (int UTF8 format)
        /// </summary>
        public string Name { get; set; }

        ///<summary>
        /// City name (in ASCII format)
        /// </summary>
        public string Name_ASCII { get; set; }

        ///<summary>
        /// City Latitude
        /// </summary>
        public decimal Lat { get; set; }

        ///<summary>
        /// City Longitude
        /// </summary>
        public decimal Lon { get; set; }
        #endregion

        ///<summary>
        /// Country Id (foreign key)
        /// </summary>
        public int CountryId { get; set; }


    }
}
