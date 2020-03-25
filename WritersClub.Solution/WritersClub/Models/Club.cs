using System.Collections.Generic;
using System;

namespace WritersClub.Models
{
  public class Club
  {
    public Club()
    {
      this.Journals = new HashSet<Journal>();
      this.ApplicationUsers = new HashSet<ApplicationUserClub>();
    }

    public string ClubName { get; set; }
    public int ClubId { get; set; }

    public ICollection<Journal> Journals { get; set; }

    public ICollection<ApplicationUserClub> ApplicationUsers { get; set; }
  }
}