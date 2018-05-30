using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanProject.Models
{
    public class Picture
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureID { get; set; }

        public string PictureUrl { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("LocationID")]
        public int LocationID { get; set; }
    }
}
