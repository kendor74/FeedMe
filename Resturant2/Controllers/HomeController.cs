using FeedMe.Models.FoodHandler;
using FeedMe.Models.MessageHandler;
using FeedMe.Models.UserMessagesHandler;
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
        
        private readonly ImessageFunc _messagesHelper;
        private readonly IuserUserMessagessFunc _usermessagesHelper;
        private readonly IfoodFunc _foodHelper;

        SignInManager<IdentityUser> _SignInManager;
        UserManager<IdentityUser> _UserManager;
        public HomeController(ILogger<HomeController> logger, ResturantDbContext context , 
            SignInManager<IdentityUser> signInManager , UserManager<IdentityUser> userManager,
            IuserUserMessagessFunc userMessageHelper , ImessageFunc messagesHelper , IfoodFunc menu)
        {
            _logger = logger;
            
            _messagesHelper = messagesHelper;
            _usermessagesHelper = userMessageHelper;

            _SignInManager = signInManager;
            _UserManager = userManager;
            _foodHelper = menu;
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





        #region Contact | Messages View

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
            _messagesHelper.Insert(msg);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult ShowMessage()
        {
            return View(_messagesHelper.GetMessages());
        }


        #endregion 
   



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}