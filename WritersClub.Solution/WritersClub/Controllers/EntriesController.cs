using Microsoft.AspNetCore.Mvc;
using WritersClub.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace WritersClub.Controllers
{
  [Authorize]
  public class EntriesController : Controller
  {
    private readonly WritersClubContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public EntriesController(UserManager<ApplicationUser> userManager, WritersClubContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userEntries = _db.Entries.Where(entry => entry.User.Id == currentUser.Id);
      return View(userEntries);
    }

    public ActionResult Create()
    {
      ViewBag.IssueId = new SelectList(_db.Issues, "IssueId", "Prompt");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Entry entry)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      entry.User = currentUser;
      _db.Entries.Add(entry);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Entry thisEntry = _db.Entries
        .Include(entry => entry.User)
        .Include(entry => entry.Issue)
        .FirstOrDefault(entries => entries.EntryId == id);
      return View(thisEntry);
    }

    public ActionResult Edit(int id)
    {
      var thisEntry = _db.Entries.FirstOrDefault(entries => entries.EntryId == id);
      ViewBag.IssueId = new SelectList(_db.Issues, "IssueId", "Prompt");
      return View(thisEntry);
    }

    [HttpPost]
    public ActionResult Edit(Entry entry)
    {
      _db.Entry(entry).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEntry = _db.Entries.FirstOrDefault(entries => entries.EntryId == id);
      return View(thisEntry);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEntry = _db.Entries.FirstOrDefault(entries => entries.EntryId == id);
      _db.Entries.Remove(thisEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}