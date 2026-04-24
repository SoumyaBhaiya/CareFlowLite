using CareFlowLite.Models;
using Microsoft.EntityFrameworkCore;

namespace CareFlowLite.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options): base(options) { }
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Incident> Incidents => Set<Incident>();
    public DbSet<RCA> RCAs => Set<RCA>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incident>()
            .HasOne(i => i.RCA)
            .WithOne(r=> r.Incident)
            .HasForeignKey<RCA>(r=>r.IncidentId);
    }
}
