using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Accounts
{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IFSC { get; set; }
        private int _Balance { get; set; }
        public string AccountSummary { get; set; }
        public string AadharNumber { get; set; }
        public string MobileNumber { get; set; }
        public void Balance(string InitialInvestment)
        {
            int amount = Convert.ToInt32(_Balance);
            _Balance = amount;
        }
        public int GetBalance()
        {
            return _Balance;
        }
    }

    public class BankAccountDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}
