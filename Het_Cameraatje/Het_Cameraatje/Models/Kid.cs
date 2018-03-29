/*  Created
 *  29 March 2018
 *  Yoeri op't Roodt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Het_Cameraatje.Models
{ 
    class Kid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kid_id { get; set; }
        public string email { get; set; }
        public int class_id { get; set; }
        public string kid_first_name { get; set; }
        public string kid_last_name { get; set; }
        public string kid_picture_url { get; set; }
    }
}
