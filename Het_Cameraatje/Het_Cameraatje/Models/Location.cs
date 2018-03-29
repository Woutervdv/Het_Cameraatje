/*  Created
 *  29 March 2018
 *  Yoeri op't Roodt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Het_Cameraatje.Models
{
    public class Location
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }

        public string LocationName { get; set; }

        public string LocationDescription { get; set; }
    }
}
