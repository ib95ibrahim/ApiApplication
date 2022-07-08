using API.entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : IdentityDbContext<Person,AppRole,int,
  IdentityUserClaim<int> , AppUserRole , IdentityUserLogin<int> , IdentityRoleClaim<int> , IdentityUserToken<int>>
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

        modelBuilder.Entity<Person>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Person)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        
        
        modelBuilder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Assistant> Assistants { get; set; }
    public DbSet<ChefEquipe> ChefEquipes { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Immigrant> Immigrants { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Rapport> Rapports { get; set; }
    public DbSet<Service> Services { get; set; }
}