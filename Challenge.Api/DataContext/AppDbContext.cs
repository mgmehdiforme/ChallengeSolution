using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ChallengeApi.Entities;
using ChallengeApi.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ChallengeApi.Entities.Configs;

namespace ChallengeApi.DataContext;

public partial class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        
    }

}
