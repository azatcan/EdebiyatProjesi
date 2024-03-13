using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDB.Domain.Entities
{
    public class LiteraryWorks
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AudioFilePath { get; set; }
        public Guid AuthorsId { get; set; }
        public Authors Authors { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
