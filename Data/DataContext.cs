using API.entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employer>().ToTable("Employer");
        modelBuilder.Entity<Assistant>().ToTable("Assistants");
        modelBuilder.Entity<ChefEquipe>().ToTable("ChefEquipes");
        modelBuilder.Entity<Immigrant>().ToTable("Immigrants");
        modelBuilder.Entity<Administrator>().ToTable("Administrators");
    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Assistant> Assistants { get; set; }
    public DbSet<ChefEquipe> ChefEquipes { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Immigrant> Immigrants { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Rapport> Rapports { get; set; }
    public DbSet<Service> Services { get; set; }
}