using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDB.Domain.Entities
{
    public class Authors
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string About { get; set; }
        public string Pseudonym { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public virtual List<LiteraryWorks> LiteraryWorks { get; set; }


    }
}
