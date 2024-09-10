using Presentation.Entities.Concrete.JournalEntry;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Entities.Concrete.PersonData
{
    public class Person:Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //[ForeignKey(nameof(Entry))]  
        //public int? EntryId {  get; set; }   
        //Navigation Property
        public virtual List<Entry>? EntryInfo { get; set; }


    }
}
