using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DendrochronologyReferenceBook.Models
{
    public class Measurement : DomainObject
    {
        public ApplicationUser User { get; set; }
        public string PreviewUrl { get; set; }
        public int SamplingYear { get; set; }
        public string Data { get; set; }
        public string LinkKoordinates { get; set; }
        public DateTime UploadDate { get; set; }
        public Specie Specie { get; set; }
       
    }
}