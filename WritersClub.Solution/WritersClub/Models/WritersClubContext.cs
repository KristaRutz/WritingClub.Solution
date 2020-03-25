using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WritersClub.Models
{
  public class WritersClubContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<ApplicationUserClub> ClubMember { get; set; }
    public virtual DbSet<Club> Club { get; set; }
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public WritersClubContext(DbContextOptions options) : base(options) { }
  }
}