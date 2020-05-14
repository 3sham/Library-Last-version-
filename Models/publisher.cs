using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class publisher
    {
        [Key]
        public int Pub_Id { get; set; }
        [Required]
        [Display(Name = "Publisher Name")]
        public string Pub_Name { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}