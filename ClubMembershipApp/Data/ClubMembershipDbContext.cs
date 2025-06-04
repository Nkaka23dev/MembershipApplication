using ClubMembershipApp.Models;
using Microsoft.EntityFrameworkCore;
namespace ClubMembershipApp.Data;

public class ClubMembershipDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ClubMembershipDb.db");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<User> Users { get; set; }
    
}
