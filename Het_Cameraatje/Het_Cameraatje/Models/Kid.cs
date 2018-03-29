/*  Created
 *  29 March 2018
 *  Yoeri op't Roodt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Het_Cameraatje.Models
{ 
    public class Kid
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KidID { get; set; }

        public string Email { get; set; } 

        [ForeignKey("ClassID")]
        public int ClassID { get; set; }

        public string KidFirstName { get; set; }

        public string KidLAstName { get; set; }

        public string KidPictureUrl { get; set; }


    }
}
