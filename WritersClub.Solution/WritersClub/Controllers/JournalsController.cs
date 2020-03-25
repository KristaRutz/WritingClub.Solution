using Microsoft.AspNetCore.Mvc;
using WritersClub.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WritersClub.Controllers
{
  public class JournalsController : Controller
  {

    private readonly WritersClubContext _db;

    public JournalsController(WritersClubContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Journal> model = _db.Journals.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.JournalId = new SelectList(_db.Journals, "JournalId", "JournalName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Journal journal)
    {
      _db.Journals.Add(journal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Journal thisJournal = _db.Journals
        .Include(journal => journal.Issues)
        .Include(journal => journal.Journal)
        .FirstOrDefault(journal => journal.JournalId == id);
      // thisJournal.Items = _db.Items.Where(item => item.JournalId == id).ToList();
      return View(thisJournal);
    }

    public ActionResult Edit(int id)
    {
      var thisJournal = _db.Journals.FirstOrDefault(journals => journals.JournalId == id);
      return View(thisJournal);
    }

    [HttpPost]
    public ActionResult Edit(Journal journal)
    {
      _db.Issue(journal).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisJournal = _db.Journals.FirstOrDefault(journals => journals.JournalId == id);
      return View(thisJournal);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisJournal = _db.Journals.FirstOrDefault(journals => journals.JournalId == id);
      _db.Journals.Remove(thisJournal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}