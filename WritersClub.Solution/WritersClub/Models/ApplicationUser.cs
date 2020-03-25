using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WritersClub.Models
{
  public class ApplicationUser : IdentityUser
  {
    public ApplicationUser() // : base()
    {
      this.Clubs = new HashSet<ApplicationUserClub>();
    }
    public ICollection<ApplicationUserClub> Clubs { get; set; }
  }
}