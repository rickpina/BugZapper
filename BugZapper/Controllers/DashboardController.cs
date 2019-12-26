using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace BugZapper.Controllers
{
    public class DashboardController : Controller
    {
        // 
        // GET: /Dashboard/

        // public IActionResult Index()
        // {
        //     return View();
        // }
        public IActionResult Dash()
        {
            return View();
        }
        // 
        // GET: /Dashboard/Welcome/ 

        // Continue Here me in the future :)
        //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-controller?view=aspnetcore-3.1&tabs=visual-studio


        public string Welcome(string name, int ID = 1)
        {
           // return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}