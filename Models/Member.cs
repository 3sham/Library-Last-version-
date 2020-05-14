using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Member
    {
        [Key]
        public int Memb_ID { get; set; }
        [Required]
        [Display(Name = "Member Name")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [Display(Name = "Date of Member")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Memb_Date { get; set; }
        [Column(TypeName = "Date")]
        [Display(Name = "Member Expiry")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Expiry_Date { get; set; }
        [Required]
        [Display(Name = "Member Type")]
        public string Memb_Type { get; set; }
       

    }
}