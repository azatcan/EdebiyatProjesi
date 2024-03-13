using EDB.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDB.Domain.Data
{
    public class DataContext : IdentityDbContext<Users, Roles, Guid>
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<LiteraryWorks> LiteraryWorks { get; set;}
        public DbSet<Storys> Stories { get; set; }
        public DbSet<Category> Category { get; set; }
        
    }
}
