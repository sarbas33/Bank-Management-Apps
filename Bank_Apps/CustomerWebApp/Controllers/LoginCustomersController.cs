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
    public class LoginCustomersController : Controller
    {
        private readonly CustomerWebAppContext _context;

        public LoginCustomersController(CustomerWebAppContext context)
        {
            _context = context;
        }

        // GET: LoginCustomers
        public async Task<IActionResult> Index()
        {
              return View(await _context.LoginCustomer.ToListAsync());
        }

        // GET: LoginCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoginCustomer == null)
            {
                return NotFound();
            }

            var loginCustomer = await _context.LoginCustomer
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (loginCustomer == null)
            {
                return NotFound();
            }

            return View(loginCustomer);
        }
        // GET: LoginCustomers/Create/Login
        public IActionResult FindAccountNumber()
        {

            return View();
        }
        // POST: LoginCustomers/Create/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FindAccountNumber([Bind("SerialNumber,AccountNumber,InternetBankingId,InternetBankingPassword")] LoginCustomer loginCustomer)
        {
            int accNumber = 0;
            //if (id == 0 || _context.LoginCustomer == null)
            //{
            //    return NotFound();
            //}
            int id = loginCustomer.InternetBankingId;
            string password=loginCustomer.InternetBankingPassword;

            var loginCustomer1 = await _context.LoginCustomer
                .FirstOrDefaultAsync(m => m.InternetBankingId == id && m.InternetBankingPassword==password);
            
            if (loginCustomer1 == null)
            {
                return NotFound();
            }
            else
            {
                accNumber = loginCustomer1.AccountNumber;
            }

            return View(loginCustomer1);

        }
        // GET: LoginCustomers/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: LoginCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerialNumber,AccountNumber,InternetBankingId,InternetBankingPassword")] LoginCustomer loginCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginCustomer);
        }

        // GET: LoginCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoginCustomer == null)
            {
                return NotFound();
            }

            var loginCustomer = await _context.LoginCustomer.FindAsync(id);
            if (loginCustomer == null)
            {
                return NotFound();
            }
            return View(loginCustomer);
        }

        // POST: LoginCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SerialNumber,AccountNumber,InternetBankingId,InternetBankingPassword")] LoginCustomer loginCustomer)
        {
            if (id != loginCustomer.SerialNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginCustomerExists(loginCustomer.SerialNumber))
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
            return View(loginCustomer);
        }

        // GET: LoginCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoginCustomer == null)
            {
                return NotFound();
            }

            var loginCustomer = await _context.LoginCustomer
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (loginCustomer == null)
            {
                return NotFound();
            }

            return View(loginCustomer);
        }

        // POST: LoginCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoginCustomer == null)
            {
                return Problem("Entity set 'CustomerWebAppContext.LoginCustomer'  is null.");
            }
            var loginCustomer = await _context.LoginCustomer.FindAsync(id);
            if (loginCustomer != null)
            {
                _context.LoginCustomer.Remove(loginCustomer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginCustomerExists(int id)
        {
          return _context.LoginCustomer.Any(e => e.SerialNumber == id);
        }
    }
}
