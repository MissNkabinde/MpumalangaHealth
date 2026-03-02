// Controllers/NewsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// At the top of your controller/cs file
using MpumalangaHealth.Models; // or MpumalangaHealth.Data.Models
using MpumalangaHealth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MpumalangaHealth.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var news = await _context.NewsItems
                .Where(n => n.PublishedDate <= DateTime.Now)
                .OrderByDescending(n => n.PublishedDate)
                .ToListAsync();

            return View(news);
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsItem = await _context.NewsItems
                .FirstOrDefaultAsync(m => m.Id == id);

            if (newsItem == null)
            {
                return NotFound();
            }

            return View(newsItem);
        }

        // Other methods...
    }
}