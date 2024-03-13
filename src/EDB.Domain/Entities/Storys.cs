using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDB.Domain.Entities
{
    public class Storys
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UsersId { get; set; }
        public Users Users { get; set; }

    }
}
