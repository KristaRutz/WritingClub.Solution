using System.Collections.Generic;
using System;

namespace WritersClub.Models
{
  public class Journal
  {
    public Journal()
    {
      this.Issues = new HashSet<Issue>();
    }
    // public int ClubId {get; set;}
    public string JournalName { get; set; }
    public int JournalId { get; set; }

    public int ClubId { get; set; }
    public virtual Club Club { get; set; }

    public ICollection<Issue> Issues { get; set; }
  }
}