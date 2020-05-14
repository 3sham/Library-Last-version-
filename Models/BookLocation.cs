using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class BookLocation
    {
        public Books Book { get; set; }
        public Locations Location { get; set; }
    }
}