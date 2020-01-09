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

        // This method inserts data into the databsse after the Action is triggered. POST: Bugs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BugsModel model)
        {
            try
            {
                MongoCRUD db = new MongoCRUD("BZBugs");
                db.InsertRecord("Bugs", model);
                return RedirectToAction(nameof(ListBugs));
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

        // POST: Bugs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, BugsModel model)
        {
            try
            {
                MongoCRUD db = new MongoCRUD("BZBugs");
                db.UpsertRecord("Bugs", id, model);
                return RedirectToAction(nameof(ListBugs));
            }
            catch
            {
                return View();
            }
        }

        // This method deletes data from the database and then redisplays the data. GET: Bugs/Delete/5
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

        // GET: Bugs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: Bugs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bugs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    } //end of Controller class
}