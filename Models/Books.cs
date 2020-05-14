using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Books
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Book_ID { get; set; }
        [Required]
        [Display(Name ="Book Title")]
        public string Title { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        [Required]
        
        public bool Available { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Author { get; set; }
        
        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        public Nullable<int> Pub_id { get; set; }

        public virtual publisher publisher { get; set; }


        public Nullable<int> Loc_id { get; set; }
        public virtual Locations location { get; set; }


    }
}