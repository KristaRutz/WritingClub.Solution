using Microsoft.AspNetCore.Mvc;
using WritersClub.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WritersClub.Controllers
{
  public class IssuesController : Controller
  {

    private readonly WritersClubContext _db;

    public IssuesController(WritersClubContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Issue> model = _db.Issues.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.JournalId = new SelectList(_db.Journals, "JournalId", "JournalName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Issue issue)
    {
      _db.Issues.Add(issue);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Issue thisIssue = _db.Issues
        .Include(issue => issue.Entries)
        .Include(issue => issue.Journal)
        .FirstOrDefault(issue => issue.IssueId == id);
      // thisIssue.Items = _db.Items.Where(item => item.IssueId == id).ToList();
      return View(thisIssue);
    }

    public ActionResult Edit(int id)
    {
      var thisIssue = _db.Issues.FirstOrDefault(issues => issues.IssueId == id);
      return View(thisIssue);
    }

    [HttpPost]
    public ActionResult Edit(Issue issue)
    {
      _db.Entry(issue).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisIssue = _db.Issues.FirstOrDefault(issues => issues.IssueId == id);
      return View(thisIssue);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisIssue = _db.Issues.FirstOrDefault(issues => issues.IssueId == id);
      _db.Issues.Remove(thisIssue);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}