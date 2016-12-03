using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DendrochronologyReferenceBook.Models
{
    public class Download : DomainObject
    {
        public ApplicationUser User { get; set; }

        public Measurement Measurement { get; set; } //на схеме в дипломе этой связи не было, только поле measurement_id

        public DateTime Date { get; set; }

    }
}