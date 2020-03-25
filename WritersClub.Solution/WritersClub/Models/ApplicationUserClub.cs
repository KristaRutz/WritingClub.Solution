namespace WritersClub.Models
{
  public class ApplicationUserClub
  {
    public int ApplicationUserClubId { get; set; }
    public int ClubId { get; set; }
    public int ApplicationUserId { get; set; }

    public Club Club { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
  }
}