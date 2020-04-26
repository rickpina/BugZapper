using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BugZapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using static BugZapper.Database;
using static BugZapper.PasswordSecurity;

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

        //Logs in user based on Username and Password and then redirects them to their Profile Page. If they enter incorrectly it will keep them at the loginpage.
        public ActionResult LoginUser(string username, string pass)
        {
            try
            {              
                MongoCRUD db = new MongoCRUD("BZBugs");
                List<LoginModel> user = db.FindLoginRecordByUsername<LoginModel>(username);

                bool isPasswordMatched = VerifyPassword(pass, user.First().Salt, user.First().Hash);
                if (isPasswordMatched)
                {
                    //Login Successfull           
                    db.FindLoginRecord<LoginModel>(username, user.First().Salt, user.First().Hash);
                    return RedirectToAction("Profile", "Home");
                }
                else
                {
                    //Login Failed
                    return RedirectToAction(nameof(LoginPage));
                }
            }
            catch
            {
                return RedirectToAction(nameof(LoginPage));
            }   
        }

        // This method inserts data into the databsse after the Action is triggered. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(LoginModel model)
        {
            try
            {
                if(ModelState.IsValid == false)
                {
                    return RedirectToAction("Signup", "Login");
                }
                GenerateSaltedHash(model, 64, model.Password);
                MongoCRUD db = new MongoCRUD("BZBugs");
                db.InsertRecord("Users", model);
                return RedirectToAction("Profile", "Home");
                //I want to Redirect this action to something more relevant like a Profile page or something.
            }
            catch
            {
                return RedirectToAction("Signup", "Login");
            }
        }
    }
}