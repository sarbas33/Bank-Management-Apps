using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

using System.Reflection;

namespace Bank_Accounts
{
    public class TransactionHistory
    {
        [Key]
        public string TransactionId { get; set; }
        public string TransactionMode { get; set; }
        public int accountNumber { get; set; }
        public string EmployeeIdIfAtBankTransaction { get; set; }
        public int Amount { get; set; }
        public string DateTime { get; set; }
        public string DebitOrCredit { get; set; }
        public int PreviousBalance { get; set; }
        public int UpdatedBalance { get; set; }

    }
    public class TransactionHistoryDBContext : DbContext
    {
        public DbSet<TransactionHistory> TransactionHistoryEntries { get; set; }
    }
}
