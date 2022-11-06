using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Accounts
{
    public class BankBalanceClass
    {
        [Key]
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public int TransactMoney(double Amount, string type)
        {
            try
            {
                if (type == "Withdrawal")
                {
                    Balance -= Amount;
                    return 1;
                }
                else
                {
                    Balance += Amount;
                    return 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
    public class BankBalanceDBContext : DbContext
    {
        public DbSet<BankBalanceClass> BankBalance { get; set; }
    }
}
