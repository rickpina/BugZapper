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

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult ListBugs()
        {
            MongoCRUD db = new MongoCRUD("BZBugs");
            List<BugsModel> bugs = db.ReadRecords<BugsModel>("Bugs");
            return View(bugs);
        }

        // GET: Bugs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bugs/Create
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

        // GET: Bugs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bugs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bugs/Delete/5
        public ActionResult Delete(int id)
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