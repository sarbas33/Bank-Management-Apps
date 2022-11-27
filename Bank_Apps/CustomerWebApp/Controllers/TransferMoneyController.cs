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

        

        private bool TransferMoneyExists(int id)
        {
          return _context.TransferMoney.Any(e => e.SerialNumber == id);
        }

        [HttpGet]
        [Route("/TransferMoney/TransferMoneyIntra")]
        public ActionResult TransferMoneyIntra()
        {
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

        }



        [HttpPost]
        [Route("/TransferMoney/TransferProcessing")]
        public ActionResult TransferProcessing([Bind("SerialNumber,FromAccountNumber,ToAccountNumber,Amount,TransactionId")] TransferMoney transfer)
        {
            int accNumber = Convert.ToInt32(TempData["AccountNumber"]);
            TempData["AccountNumber"]=accNumber;
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
