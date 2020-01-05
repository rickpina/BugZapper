using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugZapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
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

        public ActionResult ListBugs()
        {
            List<BugsModel> bugs = new List<BugsModel>
            {
                new BugsModel { BugID = 101, Status = "Unfixed", Info = "Network Bug", Date = "Today" },
                new BugsModel { BugID = 102, Status = "Fixed", Info = "Server Bug", Date = "Yesturday" },
                new BugsModel { BugID = 103, Status = "Pending", Info = "Logic Bug", Date = "Week Ago" }
            };

            return View(bugs); 
        }

    } //end of Controller class
}