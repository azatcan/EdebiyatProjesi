using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDB.Domain.Entities
{
    public class Users : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? ImagePath { get; set; }

        public string? AudioFilePath { get; set; }

    }
}
