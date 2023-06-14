using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AraneaArchives.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AraneaArchives.Models.Directory> Directory { get; set; } = default!;

        public DbSet<AraneaArchives.Models.Notes> Notes { get; set; } = default!;
    }
}