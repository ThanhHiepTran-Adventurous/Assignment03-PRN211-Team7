using eStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
namespace eStore.Controllers
{
    public class HomeController : Controller
    {

        IMemberRepository _memberRepository = null;

        public HomeController() => _memberRepository = new MemberRepository();

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public IActionResult HomeAdmin()
        {
            return View("AdminPage");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CheckLogin(Member mem)
        {
            var adminDefaultSettings = Program.Configuration.GetSection("AdminAccount").Get<DefaultAccount>();
            //lấ email từ appsetting.json để so sánh
            string _email = adminDefaultSettings.Email;
            string _password = adminDefaultSettings.Password;
            //
            string email = mem.Email;
            string password = mem.Password;
            Member member = null;
            member = _memberRepository.getMemberByPasswordAndEmail(email, password);
            if(member != null)
            {
                HttpContext.Session.SetInt32("role", 0);
                HttpContext.Session.SetInt32("id", member.MemberId);
                HttpContext.Session.SetString("email", member.Email);
                return View("EmployeePage");
            }
            else if (_email.Equals(email) && _password.Equals(password))
            {
                HttpContext.Session.SetInt32("role", 1);
                HttpContext.Session.SetString("email", email);
                return View("AdminPage");
            }
            else
            {
                TempData["fail"] = "wrong password or email";
            }
            return View("Login");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
