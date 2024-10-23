using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeanceUpdate.Models;

namespace SeanceUpdate.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SeanceUpdate.Models.NatureG10> NatureG10 { get; set; } = default!;
        public DbSet<SeanceUpdate.Models.OperationG10> OperationG10 { get; set; } = default!;
        public DbSet<SeanceUpdate.Models.CompteDetresoG10> CompteDetresoG10 { get; set; } = default!;
        public DbSet<SeanceUpdate.Models.OrdonateurG10> OrdonateurG10 { get; set; } = default!;
    }
}
