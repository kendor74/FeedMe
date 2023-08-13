using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant2.Models;
using System.Diagnostics;
using System.Globalization;

namespace Resturant2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ResturantDbContext _context;
        SignInManager<IdentityUser> _SignInManager;
        UserManager<IdentityUser> _UserManager;
        public HomeController(ILogger<HomeController> logger, ResturantDbContext context , 
            SignInManager<IdentityUser> signInManager , UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _SignInManager = signInManager;
            _UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Booking()
        {
            if (_SignInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }

            
        }

        public IActionResult Gallary()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveMessage(Message msg)
        {
            //working on auto increment of id even the model is null
            msg.MessageDescription= Request.Form["message"].ToString();
            msg.Date = DateTime.Now;
            _context.Messages.Add(msg);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult ShowMessage()
        {
            return View(_context.Messages.ToList());
        }
        //void change()
        //{
        //    CultureInfo ci = new CultureInfo("de-DE", false);
        //    Thread.CurrentThread.CurrentCulture = ci;
        //    Thread.CurrentThread.CurrentUICulture = ci;
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}