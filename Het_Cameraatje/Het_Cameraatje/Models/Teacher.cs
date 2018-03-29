/*  Created
 *  29 March 2018
 *  Yoeri op't Roodt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Het_Cameraatje.Models
{ 
    class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teacher_id { get; set; }
        public string email { get; set; }
        public string teacher_first_name { get; set; }
        public string teacher_last_name { get; set; } 
    }
}
