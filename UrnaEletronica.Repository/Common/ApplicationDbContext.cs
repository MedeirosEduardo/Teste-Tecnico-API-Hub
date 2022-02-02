using Microsoft.EntityFrameworkCore;
using System;
using UrnaEletronica.Domain;

namespace UrnaEletronica.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
