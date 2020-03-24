using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WritersClub.Models
{
  public class WritersClubContextFactory : IDesignTimeDbContextFactory<WritersClubContext>
  {
    WritersClubContext IDesignTimeDbContextFactory<WritersClubContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<WritersClubContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new WritersClubContext(builder.Options);
    }

  }
}