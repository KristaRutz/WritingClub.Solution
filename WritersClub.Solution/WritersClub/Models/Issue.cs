using System.Collections.Generic;

namespace WritersClub.Models
{
  public class Issue
  {
    public Issue()
    {
      this.Entries = new HashSet<Entry>();
    }

    public int IssueId { get; set; }
    public string Prompt { get; set; }
    public int JournalId { get; set; }
    public virtual Journal Journal { get; set; }

    // public string UserId { get; set;} // this is the prompt author...
    public virtual ICollection<Entry> Entries { get; set; }
  }
}