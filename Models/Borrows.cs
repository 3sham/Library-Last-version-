using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Borrows
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Borro_ID { get; set; }
        [Column(TypeName = "Date")]
        [Display(Name = "Date of borrow")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Due_date { get; set; }
        [Display(Name = "Return date of borrow")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Return_date { get; set; }
        public string Issue { get; set; }

        public Nullable<int> Memb_ID { get; set; }
        public virtual Member Member { get; set; }

        public Nullable<Guid> Book_id { get; set; }
        public virtual Books Book { get; set; }

      
        
    }
}