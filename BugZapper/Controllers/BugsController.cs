using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugZapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BugZapper.Database;

namespace BugZapper.Controllers
{
    public class BugsController : Controller
    {
        // GET: Bugs

        public ActionResult BugsPage()
        {
            return View();
        }

        public ActionResult CreateBug()
        {
            return View();
        }

        public ActionResult EditBug()
        {
            return View();
        }

        public ActionResult BugDetails(Guid id)
        {
            try
            {
                MongoCRUD db = new MongoCRUD("BZBugs");
                BugsModel details = db.LoadRecordById<BugsModel>("Bugs", id);
                return View(details);             
            }
            catch
            {
                return RedirectToAction(nameof(ListBugs));
            }         
        }

        // This method inserts data into the databsse after the Action is triggered. POST: Bugs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BugsModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MongoCRUD db = new MongoCRUD("BZBugs");
                    db.InsertRecord("Bugs", model);
                    return RedirectToAction(nameof(ListBugs));
                }
                else
                {
                    return View("CreateBug", model);
                }
                
            }
            catch
            {
                return View();
            }
        }

        //This method reads the records from the database and returns the data to a view. 
        public ActionResult ListBugs()
        {
            MongoCRUD db = new MongoCRUD("BZBugs");
            List<BugsModel> bugs = db.ReadRecords<BugsModel>("Bugs");
            return View(bugs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, BugsModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MongoCRUD db = new MongoCRUD("BZBugs");
                    db.UpsertRecord("Bugs", id, model);
                    return RedirectToAction(nameof(ListBugs));
                }
                else
                {
                    return View("EditBug", model);
                }
            }
            catch
            {
                return View("EditBug");
            }
        }

        // This method deletes data from the database and then redisplays the data.
        public ActionResult DeleteBug(Guid id)
        {
            try
            {
                MongoCRUD db = new MongoCRUD("BZBugs");
                db.DeleteRecord<BugsModel>("Bugs", id);
                return RedirectToAction(nameof(ListBugs));
            }
            catch
            {
                return View();
            }
        }

    } //end of Controller class
} //end of namespace