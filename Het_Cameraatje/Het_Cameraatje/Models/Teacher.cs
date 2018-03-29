/*  Created
 *  29 March 2018
 *  Yoeri op't Roodt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Het_Cameraatje.Models
{ 
    public class Teacher
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherID { get; set; }

        public string Email { get; set; }

        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; } 
    }
}
