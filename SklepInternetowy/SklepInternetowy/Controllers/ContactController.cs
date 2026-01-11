using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SklepInternetowy.Data;
using SklepInternetowy.Models;

namespace SklepInternetowy.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                contactMessage.SentDate = DateTime.Now;
                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Success));
            }
            return View(contactMessage);
        }

        public IActionResult Success()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var messages = await _context.ContactMessages
                                         .OrderByDescending(m => m.SentDate)
                                         .ToListAsync();
            return View(messages);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _context.ContactMessages.FindAsync(id);
            if (message != null)
            {
                _context.ContactMessages.Remove(message);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}