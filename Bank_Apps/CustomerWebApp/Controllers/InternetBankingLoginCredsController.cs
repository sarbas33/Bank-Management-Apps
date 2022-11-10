using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerWebApp.Data;
using CustomerWebApp.Models;

namespace CustomerWebApp.Controllers
{
    public class InternetBankingLoginCredsController : Controller
    {
        private readonly CustomerWebAppContext _context;

        public InternetBankingLoginCredsController(CustomerWebAppContext context)
        {
            _context = context;
        }

        // GET: InternetBankingLoginCreds
        public async Task<IActionResult> Index()
        {
              return View(await _context.InternetBankingLoginCreds.ToListAsync());
        }

        // GET: InternetBankingLoginCreds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InternetBankingLoginCreds == null)
            {
                return NotFound();
            }

            var internetBankingLoginCreds = await _context.InternetBankingLoginCreds
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (internetBankingLoginCreds == null)
            {
                return NotFound();
            }

            return View(internetBankingLoginCreds);
        }

        // GET: InternetBankingLoginCreds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InternetBankingLoginCreds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerialNumber,AccountNumber,InternetBankingId,InternetBankingPassword")] InternetBankingLoginCreds internetBankingLoginCreds)
        {
            if (ModelState.IsValid)
            {
                _context.Add(internetBankingLoginCreds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(internetBankingLoginCreds);
        }

        // GET: InternetBankingLoginCreds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InternetBankingLoginCreds == null)
            {
                return NotFound();
            }

            var internetBankingLoginCreds = await _context.InternetBankingLoginCreds.FindAsync(id);
            if (internetBankingLoginCreds == null)
            {
                return NotFound();
            }
            return View(internetBankingLoginCreds);
        }

        // POST: InternetBankingLoginCreds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SerialNumber,AccountNumber,InternetBankingId,InternetBankingPassword")] InternetBankingLoginCreds internetBankingLoginCreds)
        {
            if (id != internetBankingLoginCreds.SerialNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internetBankingLoginCreds);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternetBankingLoginCredsExists(internetBankingLoginCreds.SerialNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(internetBankingLoginCreds);
        }

        // GET: InternetBankingLoginCreds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InternetBankingLoginCreds == null)
            {
                return NotFound();
            }

            var internetBankingLoginCreds = await _context.InternetBankingLoginCreds
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (internetBankingLoginCreds == null)
            {
                return NotFound();
            }

            return View(internetBankingLoginCreds);
        }

        // POST: InternetBankingLoginCreds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InternetBankingLoginCreds == null)
            {
                return Problem("Entity set 'CustomerWebAppContext.InternetBankingLoginCreds'  is null.");
            }
            var internetBankingLoginCreds = await _context.InternetBankingLoginCreds.FindAsync(id);
            if (internetBankingLoginCreds != null)
            {
                _context.InternetBankingLoginCreds.Remove(internetBankingLoginCreds);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternetBankingLoginCredsExists(int id)
        {
          return _context.InternetBankingLoginCreds.Any(e => e.SerialNumber == id);
        }
    }
}
