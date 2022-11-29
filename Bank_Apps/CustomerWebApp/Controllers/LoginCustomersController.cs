using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerWebApp.Data;
using CustomerWebApp.Models;
using Microsoft.CodeAnalysis;

namespace CustomerWebApp.Controllers
{
    public class LoginCustomersController : Controller
    {
        private readonly CustomerWebAppContext _context;
        private readonly BankAccountDBContext _AccountDetailscontext= new BankAccountDBContext();
        private double balance;

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
        // GET: LoginCustomers/Create/Login/FindAccountNumber
        public IActionResult FindAccountNumber()
        {

            return View();
        }
        // POST: LoginCustomers/Create/Login/FindAccountNumber
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
                TempData["AccountNumber"] = loginCustomer1.AccountNumber;
            }
            

            return View("FindAccountNumber",  _AccountDetailscontext.Accounts.Where(j => j.AccountNumber == loginCustomer1.AccountNumber).FirstOrDefault());
            //return View("FindAccountNumber",await _context.Account.Where(j=> j.AccountNumber == loginCustomer1.AccountNumber).ToListAsync());

        }

        // GET: LoginCustomers/Create/Login/GetBankBalance
        public IActionResult GetBankBalance()
        {
            return View();
        }

        // GET: LoginCustomers/Create/Login/GetBankBalance
        public IActionResult TransferMoneyIntra()
        {
            return View();
        }
        // POST: LoginCustomers/Create/Login/GetBankBalance
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TransferMoneyIntra([Bind("AccountNumber", "FirstName", "LastName", "Ifsc", "MobileNumber")] Account loginCustomer)
        {
            //int accNumber = 0;
            //int accNum = loginCustomer.AccountNumber;
            int accNumber = Convert.ToInt32(TempData["AccountNumber"]);

            var loginCustomer1 = await _context.LoginCustomer
                .FirstOrDefaultAsync(m => m.AccountNumber == accNumber);

            if (loginCustomer1 == null)
            {
                return NotFound();
            }
            else
            {
                accNumber = loginCustomer1.AccountNumber;
            }

            TempData["BankBalance"] = _AccountDetailscontext.BankBalanceClasses.Where(j => j.AccountNumber == loginCustomer1.AccountNumber).FirstOrDefault().Balance.ToString();

            return View("GetBankBalance", _AccountDetailscontext.Accounts.Where(j => j.AccountNumber == loginCustomer1.AccountNumber).FirstOrDefault());
            //return View("FindAccountNumber",await _context.Account.Where(j=> j.AccountNumber == loginCustomer1.AccountNumber).ToListAsync());

        }
        // GET: LoginCustomers/LogIn
        public IActionResult LogIn()
        {
            return View("Create");
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

        [HttpGet]
        [Route("/LoginCustomers/LogOut")]
        public ActionResult LogOut()
        {
            TempData.Clear();
            return View("Create");
        }

    }
}
