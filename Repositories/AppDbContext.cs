using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Test_Miangaly.Models;

namespace Test_Miangaly.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Personne> Personnes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public AppDbContext() { }
}
