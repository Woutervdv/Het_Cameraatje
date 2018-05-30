using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanProject.Models
{
    public class Pictures
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureCount { get; set; }

        [ForeignKey("PictureID")]
        public int PictureID { get; set; }

        [ForeignKey("KidID")]
        public int KidID { get; set; }
    }
}
