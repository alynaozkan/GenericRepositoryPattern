using Microsoft.EntityFrameworkCore;
using Presentation.Entities.Concrete.JournalEntry;
using Presentation.Entities.Concrete.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.DataAccess.Context
{
    public class MyBlogDbContext : DbContext
    {
        public MyBlogDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Person> Persons { get; set; }  
        public DbSet<Entry> Entries { get; set; }     

    }
}
