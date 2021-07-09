using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanDapper.CORE.Entity.Concrete;

namespace CleanDapper.API.Data
{
    public class CleanDapperAPIContext : DbContext
    {
        public CleanDapperAPIContext (DbContextOptions<CleanDapperAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CleanDapper.CORE.Entity.Concrete.Category> Category { get; set; }
    }
}
