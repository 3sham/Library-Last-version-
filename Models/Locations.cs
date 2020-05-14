using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Locations
    {
        [Key]
        public int Loc_ID { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Room { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public string shelf { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}