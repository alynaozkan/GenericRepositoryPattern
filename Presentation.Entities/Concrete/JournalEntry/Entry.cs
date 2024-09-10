using Presentation.Entities.Abstract;
using Presentation.Entities.Concrete.PersonData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Entities.Concrete.JournalEntry
{
    public class Entry : Entity
    {
        public string Content { get; set; }

        public string Title { get; set; }   
        public DateTime Date { get; set; }  = DateTime.Now;

        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public virtual Person? Person { get; set; }

    }
}
