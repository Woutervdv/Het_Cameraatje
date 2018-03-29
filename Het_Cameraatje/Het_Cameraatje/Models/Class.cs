/*  Created
 *  29 March 2018
 *  Yoeri op't Roodt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Het_Cameraatje.Models
{
    class Class
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }

        [ForeignKey("TeacherID")]
        public int TeacherID { get; set; }

        public string ClassName { get; set; }
    }
}
