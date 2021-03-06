﻿/*  Created
 *  29 March 2018
 *  Yoeri op't Roodt
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Het_Cameraatje.Models
{
    public class Picture
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureID { get; set; }

        public string PictureUrl { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("LocationID")]
        public int LocationID { get; set; }
    }
}
