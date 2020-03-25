using System.Collections.Generic;
using System;

namespace WritersClub.Models
{
  public class Entry
  {
    public string Title { get; set; }
    public int EntryId { get; set; }
    public int IssueId { get; set; }
    public virtual Issue Issue { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}