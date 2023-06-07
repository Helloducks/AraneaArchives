using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AraneaArchives.Models;

namespace AraneaArchives.Data
{
    public class AraneaArchivesContext : DbContext
    {
        public AraneaArchivesContext (DbContextOptions<AraneaArchivesContext> options)
            : base(options)
        {
        }

        public DbSet<AraneaArchives.Models.Directory> Directory { get; set; } = default!;

        public DbSet<AraneaArchives.Models.Notes> Notes { get; set; } = default!;
    }
}
