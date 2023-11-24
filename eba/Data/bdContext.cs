using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eba.Models;

namespace eba.Data
{
    public class bdContext : DbContext
    {
        public bdContext (DbContextOptions<bdContext> options)
            : base(options)
        {
        }

        public DbSet<eba.Models.cadclientes> cadclientes { get; set; } = default!;

        public DbSet<eba.Models.cadmaquinas> cadmaquinas { get; set; } = default!;

        public DbSet<eba.Models.inventario> inventario { get; set; } = default!;
    }
}
