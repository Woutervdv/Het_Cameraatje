/*  Created
 *  29 March 2018
 *  Yoeri op't Roodt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Het_Cameraatje.Models
{
    public class Pictures
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureCount { get; set; }

        [ForeignKey("PictureID")]
        public int PictureID { get; set; }

        [ForeignKey("KidID")]
        public int KidID { get; set; }
    }
}
