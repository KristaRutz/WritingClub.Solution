using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WritersClub.Models
{
  public class WritersClubContext : IdentityDbContext<ApplicationUser>
  {
    // public virtual DbSet<Category> Categories { get; set; }
    // public DbSet<Item> Items { get; set; }
    // public DbSet<CategoryItem> CategoryItems { get; set; }
    public WritersClubContext(DbContextOptions options) : base(options) { }
  }
}