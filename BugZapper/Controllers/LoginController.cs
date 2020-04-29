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
using Microsoft.AspNetCore.Authorization;

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
                //this checks if there is valid data in the required fields (Username, Password)
                if (ModelState.IsValid)
                {
                    MongoCRUD db = new MongoCRUD("BZBugs");

                    //This checks if the username is unique or not.
                    if (db.CheckIfUsernameIsUnique<LoginModel>(model.Username) == true)
                    {
                        //Failure State    
                        ModelState.AddModelError("Username", "This Username already exists.");
                        return View("SignUp", model);
                    }                 
                    GenerateSaltedHash(model, 64, model.Password);
                    db.InsertRecord("Users", model);
                    //I want to Redirect this action to something more relevant like a Profile page or something.
                    //Success
                    return RedirectToAction("Profile", "Home");                    
                }
                //Failure State
                return View("SignUp", model);               
            }
            catch
            {
                //Failure State
                return View("SignUp", model);
            }
        }
    }//end of class
}//end of namespace