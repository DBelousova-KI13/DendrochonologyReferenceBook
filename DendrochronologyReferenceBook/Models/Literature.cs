using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DendrochronologyReferenceBook.Models
{
    public class Literature : DomainObject
    {
        public ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string DownloadFormat { get; set; }

        public string Comment { get; set; }


    }
}