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
    public class AccountsController : Controller
    {
        private readonly CustomerWebAppContext _context;
        private readonly BankAccountDBContext _AccountDetailscontext = new BankAccountDBContext();
        private double balance;

        public AccountsController(CustomerWebAppContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Account.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountNumber,FirstName,LastName,Ifsc,AccountSummary,AadharNumber,MobileNumber")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetBankBalance([Bind("AccountNumber", "FirstName", "LastName", "Ifsc", "MobileNumber")] Account loginCustomer)
        {
            //int accNumber = 0;
            //int accNum = loginCustomer.AccountNumber;
            int accNumber = Convert.ToInt32(TempData["AccountNumber"]);
            TempData["AccountNumber"] = accNumber.ToString();

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
        
        private bool AccountExists(int id)
        {
          return _context.Account.Any(e => e.AccountNumber == id);
        }

        [HttpGet]
        [Route("/Accounts/TransferMoneyIntra/{id}")]
        public ActionResult TransferMoneyIntra(string id)
        {
            //int accNumber = 0;
            //int accNum = loginCustomer.AccountNumber;
            int accNumber = Convert.ToInt32(TempData["AccountNumber"]);

            var loginCustomer1 = _context.LoginCustomer.FirstOrDefault(m => m.AccountNumber == accNumber);

            if (loginCustomer1 == null)
            {
                return NotFound();
            }
            else
            {
                accNumber = loginCustomer1.AccountNumber;
            }
            TempData["AccountNumber"] = _AccountDetailscontext.BankBalanceClasses.Where(j => j.AccountNumber == loginCustomer1.AccountNumber).FirstOrDefault().AccountNumber.ToString();
            TempData["BankBalance"] = _AccountDetailscontext.BankBalanceClasses.Where(j => j.AccountNumber == loginCustomer1.AccountNumber).FirstOrDefault().Balance.ToString();

            return View("", _AccountDetailscontext.Accounts.Where(j => j.AccountNumber == loginCustomer1.AccountNumber).FirstOrDefault());
            //return View("FindAccountNumber",await _context.Account.Where(j=> j.AccountNumber == loginCustomer1.AccountNumber).ToListAsync());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FindAccount([Bind("SerialNumber,AccountNumber,InternetBankingId,InternetBankingPassword")] LoginCustomer loginCustomer)
        {
            int accNumber = 0;
            //if (id == 0 || _context.LoginCustomer == null)
            //{
            //    return NotFound();
            //}
            int id = loginCustomer.InternetBankingId;
            string password = loginCustomer.InternetBankingPassword;

            var loginCustomer1 = await _context.LoginCustomer
                .FirstOrDefaultAsync(m => m.InternetBankingId == id && m.InternetBankingPassword == password);

            if (loginCustomer1 == null)
            {
                return NotFound();
            }
            else
            {
                TempData["AccountNumber"] = loginCustomer1.AccountNumber;
            }


            return View("FindAccountNumber", _AccountDetailscontext.Accounts.Where(j => j.AccountNumber == loginCustomer1.AccountNumber).FirstOrDefault());
            //return View("FindAccountNumber",await _context.Account.Where(j=> j.AccountNumber == loginCustomer1.AccountNumber).ToListAsync());

        }
        [HttpGet]
        [Route("/Accounts/AccountPage")]
        public ActionResult AccountPage()
        {
            int accNumber = Convert.ToInt32(TempData["AccountNumber"]);
            TempData["AccountNumber"] = accNumber;
            return View("FindAccountNumber", _AccountDetailscontext.Accounts.Where(j => j.AccountNumber == accNumber).FirstOrDefault());
        }
    }
}
