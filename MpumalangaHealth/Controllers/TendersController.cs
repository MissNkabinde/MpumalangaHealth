using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpumalangaHealth.Data;
using MpumalangaHealth.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MpumalangaHealth.Controllers
{
    public class TendersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TendersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tenders
        public async Task<IActionResult> Index(string status = "", string category = "")
        {
            ViewBag.CurrentStatus = status;
            ViewBag.CurrentCategory = category;

            // Start with base query - only published and not future dated
            var tendersQuery = _context.Tenders
                .Where(t => t.IsPublished && t.PublishedDate <= DateTime.Now);

            // Apply filters
            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Open")
                {
                    tendersQuery = tendersQuery
                        .Where(t => (t.Status == "Open" || t.Status == "Closing Soon")
                            && t.ClosingDate >= DateTime.Now);
                }
                else if (status == "ClosingSoon")
                {
                    tendersQuery = tendersQuery
                        .Where(t => (t.Status == "Open" || t.Status == "Closing Soon")
                            && t.ClosingDate <= DateTime.Now.AddDays(7)
                            && t.ClosingDate >= DateTime.Now);
                }
            }
            else if (!string.IsNullOrEmpty(category))
            {
                tendersQuery = tendersQuery.Where(t => t.Category == category);
            }

            // Get the tenders
            var tenders = await tendersQuery
                .OrderByDescending(t => t.PublishedDate)
                .ToListAsync();

            // Get statistics
            ViewBag.OpenTenders = await _context.Tenders
                .CountAsync(t => (t.Status == "Open" || t.Status == "Closing Soon")
                    && t.ClosingDate >= DateTime.Now
                    && t.IsPublished);

            ViewBag.ClosingSoon = await _context.Tenders
                .CountAsync(t => (t.Status == "Open" || t.Status == "Closing Soon")
                    && t.ClosingDate <= DateTime.Now.AddDays(7)
                    && t.ClosingDate >= DateTime.Now
                    && t.IsPublished);

            ViewBag.ClosedTenders = await _context.Tenders
                .CountAsync(t => t.Status == "Closed" && t.IsPublished);

            ViewBag.TotalTenders = await _context.Tenders
                .CountAsync(t => t.IsPublished);

            // Featured tenders - using highest budget as featured since IsFeatured doesn't exist
            ViewBag.FeaturedTenders = await _context.Tenders
                .Where(t => (t.Status == "Open" || t.Status == "Closing Soon")
                    && t.ClosingDate >= DateTime.Now
                    && t.IsPublished)
                .OrderByDescending(t => t.Budget)
                .Take(3)
                .ToListAsync();

            return View(tenders);
        }

        // GET: Tenders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var tender = await _context.Tenders
                .FirstOrDefaultAsync(t => t.Id == id && t.IsPublished);

            if (tender == null)
            {
                return NotFound();
            }

            // Get related tenders (same category)
            ViewBag.RelatedTenders = await _context.Tenders
                .Where(t => t.Category == tender.Category
                    && t.Id != tender.Id
                    && t.IsPublished
                    && t.PublishedDate <= DateTime.Now)
                .OrderByDescending(t => t.PublishedDate)
                .Take(3)
                .ToListAsync();

            return View(tender);
        }

        // GET: Tenders/Category/Medical Equipment
        public async Task<IActionResult> Category(string category)
        {
            var tenders = await _context.Tenders
                .Where(t => t.Category == category
                    && t.IsPublished
                    && t.PublishedDate <= DateTime.Now)
                .OrderByDescending(t => t.PublishedDate)
                .ToListAsync();

            ViewBag.Category = category;
            ViewBag.CurrentCategory = category;

            // Get statistics
            ViewBag.OpenTenders = await _context.Tenders
                .CountAsync(t => (t.Status == "Open" || t.Status == "Closing Soon")
                    && t.ClosingDate >= DateTime.Now
                    && t.IsPublished);
            ViewBag.TotalTenders = await _context.Tenders.CountAsync(t => t.IsPublished);

            return View("Index", tenders);
        }

        // GET: Tenders/Open
        public async Task<IActionResult> Open()
        {
            var tenders = await _context.Tenders
                .Where(t => (t.Status == "Open" || t.Status == "Closing Soon")
                    && t.ClosingDate >= DateTime.Now
                    && t.IsPublished
                    && t.PublishedDate <= DateTime.Now)
                .OrderBy(t => t.ClosingDate)
                .ToListAsync();

            ViewBag.Title = "Open Tenders";
            ViewBag.CurrentStatus = "Open";

            // Get statistics
            ViewBag.OpenTenders = tenders.Count;
            ViewBag.TotalTenders = await _context.Tenders.CountAsync(t => t.IsPublished);

            return View("Index", tenders);
        }

        // GET: Tenders/ClosingSoon
        public async Task<IActionResult> ClosingSoon()
        {
            var tenders = await _context.Tenders
                .Where(t => (t.Status == "Open" || t.Status == "Closing Soon")
                    && t.ClosingDate <= DateTime.Now.AddDays(7)
                    && t.ClosingDate >= DateTime.Now
                    && t.IsPublished
                    && t.PublishedDate <= DateTime.Now)
                .OrderBy(t => t.ClosingDate)
                .ToListAsync();

            ViewBag.Title = "Closing Soon";
            ViewBag.CurrentStatus = "ClosingSoon";

            // Get statistics
            ViewBag.ClosingSoon = tenders.Count;
            ViewBag.TotalTenders = await _context.Tenders.CountAsync(t => t.IsPublished);

            return View("Index", tenders);
        }

        // GET: Tenders/Search
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index");
            }

            var tenders = await _context.Tenders
                .Where(t => t.IsPublished && t.PublishedDate <= DateTime.Now)
                .Where(t =>
                    t.Title.Contains(query) ||
                    t.TenderNumber.Contains(query) ||
                    t.Description.Contains(query) ||
                    t.Department.Contains(query) ||
                    t.Category.Contains(query))
                .OrderByDescending(t => t.PublishedDate)
                .ToListAsync();

            ViewBag.SearchQuery = query;
            ViewBag.TotalTenders = await _context.Tenders.CountAsync(t => t.IsPublished);

            return View("Index", tenders);
        }

        // GET: Tenders/DownloadDocument/5
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var tender = await _context.Tenders
                .FirstOrDefaultAsync(t => t.Id == id && t.IsPublished);

            if (tender == null || string.IsNullOrEmpty(tender.DocumentUrl))
            {
                TempData["ErrorMessage"] = "Document not found.";
                return RedirectToAction("Details", new { id });
            }

            // Redirect to the document URL
            return Redirect(tender.DocumentUrl);
        }
    }
}