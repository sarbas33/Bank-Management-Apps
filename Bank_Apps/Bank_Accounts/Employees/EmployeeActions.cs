using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

using System.Reflection;
using System.Diagnostics.Tracing;

namespace Bank_Accounts
{
    class EmployeeActions
    {
        public string GetAccountHolderName(int AccountNumber)
        {
            try
            {
                using (var context = new BankAccountDBContext())
                {
                    var query = from Acc in context.Accounts
                                where Acc.AccountNumber == AccountNumber
                                select Acc;
                    var account = query.FirstOrDefault();
                    return account.FirstName + " " + account.LastName;
                }
            }
            catch
            {
                return "Invalid Account Number";
            }
        }
        public bool CreateNewBankAccount(string firstName, string lastName, string IFSC, string aadhar, string mobile, string InitialAmount)
        {
            var context = new BankAccountDBContext();
            Account account = new Account();
            account.FirstName = firstName;
            account.LastName = lastName;
            account.IFSC = IFSC;
            account.AadharNumber = aadhar;
            account.MobileNumber = mobile;
            account.Balance(InitialAmount);
            context.Accounts.Add(account);
            context.SaveChanges();

            string accNumber;
            using (var context2=new BankAccountDBContext())
            {
                var query = from Acc in context2.Accounts
                            where (Acc.MobileNumber==mobile) && (Acc.FirstName==firstName)
                            select Acc;
                var acc=query.FirstOrDefault();
                accNumber= acc.AccountNumber.ToString();
                MessageBox.Show("Account Created with account Number: "+ accNumber);
                
            }
            using (var context3 = new BankBalanceDBContext())
            {
                BankBalanceClass objBankBalance = new BankBalanceClass();
                objBankBalance.AccountNumber = Convert.ToInt32(accNumber);
                objBankBalance.Balance = Convert.ToInt32(InitialAmount);
                context3.BankBalance.Add(objBankBalance);
                context3.SaveChanges();
            }
            
            
            return true;

        }
        public int LoginEmployee(string Username, string password)
        {
            using (var context3 = new EmployeeDBContext())
            {
                var query = from Emp in context3.Employees
                            where Emp.UserName == Username
                            select Emp;
                var emp=query.FirstOrDefault();
                if (emp.Password == password)
                {
                    MessageBox.Show("LoginEmployee Successful");   
                    return emp.Id;
                }
                else return 0;
            }
        }
        public int[] WithDraw(int AccountNum, int Amount,string transactionId)
        {
            int prevBalance = 0;
            int updatedBalance = 0;
                using (var context=new BankBalanceDBContext())
                {
                    var query = from Acc in context.BankBalance
                                where Acc.AccountNumber == AccountNum
                                select Acc;
                    var account=query.FirstOrDefault();
                    
                    if (account!=null)
                    {
                        prevBalance = Convert.ToInt32(account.Balance);
                        account.TransactMoney(Amount, "Withdrawal");
                        context.SaveChanges();
                    }
                    updatedBalance = Convert.ToInt32(account.Balance);
                }
                MessageBox.Show("Withdrawn " + Amount.ToString() + " from Account Number: "+AccountNum.ToString());
            int[] returnArray = {prevBalance, updatedBalance};
            return returnArray;
        }
        public int[] Deposit(int AccountNum, int Amount, string transactionId)
        {
            int prevBalance = 0;
            int updatedBalance = 0;
            using (var context = new BankBalanceDBContext())
            {
                var query = from Acc in context.BankBalance
                            where Acc.AccountNumber == AccountNum
                            select Acc;
                var account = query.FirstOrDefault();

                if (account != null)
                {
                    prevBalance = Convert.ToInt32(account.Balance);
                    account.TransactMoney(Amount, "Deposit");
                }
                context.BankBalance.Attach(account);
                context.SaveChanges();
                updatedBalance = Convert.ToInt32(account.Balance);
            }
            
            MessageBox.Show("Deposited " + Amount.ToString() + " to Account Number: " + AccountNum.ToString());
            int[] returnArray = { prevBalance, updatedBalance }; 
            return returnArray;
        }
        public bool logTransHistory(string TransID, string transMode,int accNumber,int Amount, string DateTime, int employeeID, string DebOrCred, int prevBalance, int currBalance)
        {

            var context = new TransactionHistoryDBContext();
            TransactionHistory transactionHis = new TransactionHistory();
            transactionHis.TransactionId = TransID;
            transactionHis.TransactionMode = transMode;
            transactionHis.accountNumber = accNumber;
            transactionHis.Amount=Amount;
            transactionHis.DateTime = DateTime;
            transactionHis.EmployeeIdIfAtBankTransaction = employeeID.ToString();
            transactionHis.PreviousBalance = prevBalance;
            transactionHis.DebitOrCredit = DebOrCred;
            transactionHis.UpdatedBalance = currBalance;
            context.TransactionHistoryEntries.Add(transactionHis);
            //context.Entry(transactionHis);
            context.TransactionHistoryEntries.Add(transactionHis);
            context.SaveChanges();  
            
            return true;
        }
        
    }
}
