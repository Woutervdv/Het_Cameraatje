using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanProject.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }

        [ForeignKey("TeacherID")]
        public int TeacherID { get; set; }

        public string ClassName { get; set; }

        public string ClassPictureUrl { get; set; }
    }
}
