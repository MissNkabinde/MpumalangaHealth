using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpumalangaHealth.Data;
using MpumalangaHealth.Models;

namespace MpumalangaHealth.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login - SIMPLE VERSION
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // SIMPLE HARDCODED CHECK - Remove later
            if (username == "admin" && password == "pass1")
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("AdminName", "Test Administrator");
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid login";
            return View();
        }

        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
                return RedirectToAction("Login");

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}