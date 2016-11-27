using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DendrochronologyReferenceBook.Models
{
    public class City : DomainObject
    {
        public string Name { get; set; }

        public Country Country { get; set; }
    }
}