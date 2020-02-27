using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugZapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BugZapper.Database;

//Sign In is under the Home folder but the Controller it will be using is in Login. This will probably confuse me in the future so change that if its an issue.

namespace BugZapper.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        // This method inserts data into the databsse after the Action is triggered. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginModel model)
        {
            try
            {
                MongoCRUD db = new MongoCRUD("BZBugs");
                db.InsertRecord("Users", model);
                return RedirectToAction(nameof(LoginPage));
                //I want to Redirect this action to something more relevant like a Profile page or something.
            }
            catch
            {
                return View();
            }
        }
    }
}