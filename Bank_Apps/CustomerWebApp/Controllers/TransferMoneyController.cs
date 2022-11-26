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
    public class TransferMoneyController : Controller
    {
        private readonly CustomerWebAppContext _context;
        private readonly BankAccountDBContext _AccountDetailscontext = new BankAccountDBContext();
        private double balance;

        public TransferMoneyController(CustomerWebAppContext context)
        {
            _context = context;
        }

        // GET: TransferMoney
        public async Task<IActionResult> Index()
        {
              return View(await _context.TransferMoney.ToListAsync());
        }

        // GET: TransferMoney/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransferMoney == null)
            {
                return NotFound();
            }

            var transferMoney = await _context.TransferMoney
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (transferMoney == null)
            {
                return NotFound();
            }

            return View(transferMoney);
        }

        // GET: TransferMoney/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransferMoney/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerialNumber,FromAccountNumber,ToAccountNumber,Amount,TransactionId")] TransferMoney transferMoney)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transferMoney);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transferMoney);
        }

        // GET: TransferMoney/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransferMoney == null)
            {
                return NotFound();
            }

            var transferMoney = await _context.TransferMoney.FindAsync(id);
            if (transferMoney == null)
            {
                return NotFound();
            }
            return View(transferMoney);
        }

        // POST: TransferMoney/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SerialNumber,FromAccountNumber,ToAccountNumber,Amount,TransactionId")] TransferMoney transferMoney)
        {
            if (id != transferMoney.SerialNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferMoney);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferMoneyExists(transferMoney.SerialNumber))
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
            return View(transferMoney);
        }

        // GET: TransferMoney/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransferMoney == null)
            {
                return NotFound();
            }

            var transferMoney = await _context.TransferMoney
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (transferMoney == null)
            {
                return NotFound();
            }

            return View(transferMoney);
        }

        // POST: TransferMoney/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransferMoney == null)
            {
                return Problem("Entity set 'CustomerWebAppContext.TransferMoney'  is null.");
            }
            var transferMoney = await _context.TransferMoney.FindAsync(id);
            if (transferMoney != null)
            {
                _context.TransferMoney.Remove(transferMoney);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransferMoneyExists(int id)
        {
          return _context.TransferMoney.Any(e => e.SerialNumber == id);
        }

        [HttpGet]
        [Route("/TransferMoney/TransferMoneyIntra")]
        public ActionResult TransferMoneyIntra()
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

            return View("TransferMoneyIntra");
            //return View("FindAccountNumber",await _context.Account.Where(j=> j.AccountNumber == loginCustomer1.AccountNumber).ToListAsync());

        }

        [HttpPost]
        [Route("/TransferMoney/TransferProcessing")]
        public ActionResult TransferProcessing([Bind("SerialNumber,FromAccountNumber,ToAccountNumber,Amount,TransactionId")] TransferMoney transfer)
        {
            int accNumber = Convert.ToInt32(TempData["AccountNumber"]);
            int ToAccountNumber = transfer.ToAccountNumber;
            int Amount = transfer.Amount;
            int SerNo = transfer.SerialNumber;
            int FromAccNumber = transfer.FromAccountNumber;

            string dateTime = DateTime.Now.ToString("G");
            string dateTimeInt = dateTime.Replace(@" ", String.Empty).Replace(@":", String.Empty).Replace(@"-", String.Empty);
            string transactionID = dateTimeInt + accNumber;

            transfer.TransactionId=transactionID;
            transfer.FromAccountNumber = accNumber;
            _context.TransferMoney.Add(transfer);
            _context.SaveChanges();

            var fromAccount = _AccountDetailscontext.BankBalanceClasses.Where(j => j.AccountNumber == accNumber).FirstOrDefault();
            fromAccount.Balance-=Amount;

            var toAccount = _AccountDetailscontext.BankBalanceClasses.Where(j => j.AccountNumber == ToAccountNumber).FirstOrDefault();
            toAccount.Balance += Amount;
            _AccountDetailscontext.SaveChanges();

            return View("TransferStatus");
        }

    }
}
