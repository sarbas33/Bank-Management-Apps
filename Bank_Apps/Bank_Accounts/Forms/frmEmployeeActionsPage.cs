using Bank_Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeeForm
{
    public partial class frmEmployeeActionsPage : Form
    {
        int empID;
        EmployeeActions emp = new EmployeeActions();
        public frmEmployeeActionsPage(int employeeID)
        {
            empID=employeeID;
            InitializeComponent();
        }

        private void ManageAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmEmployeeLogin.form1.Show();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            emp.CreateNewBankAccount(this.txtFirstName.Text, this.txtLastName.Text, this.txtIFSC.Text, this.txtAadhar.Text, this.txtMobile.Text, this.txtAmount.Text);
        }

        private void btnGetAccountHolderName_Click(object sender, EventArgs e)
        {
            string accNumber = txtWithDrawAccountNumber.Text;
            string Name = emp.GetAccountHolderName(Convert.ToInt32(accNumber));
            MessageBox.Show("Pleas Verify Mr. " + Name + " is Present in the bank");
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            string accNumber = txtWithDrawAccountNumber.Text;
            string dateTime = DateTime.Now.ToString("G");
            string dateTimeInt=dateTime.Replace(@" ", String.Empty).Replace(@":",String.Empty).Replace(@"-",String.Empty);
            string transactionID = dateTimeInt + accNumber;
            int[] transResult= emp.WithDraw(Convert.ToInt32(accNumber), Convert.ToInt32(txtWithDrawAmount.Text), transactionID);
            emp.logTransHistory(transactionID,"FromBank", Convert.ToInt32(accNumber), Convert.ToInt32(txtWithDrawAmount.Text), dateTimeInt, empID, "Debit", transResult[0], transResult[1]);

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            string accNumber = txtDepositAccNum.Text;
            string dateTime = DateTime.Now.ToString("G");
            string dateTimeInt = dateTime.Replace(@" ", String.Empty).Replace(@":", String.Empty).Replace(@"-", String.Empty);
            string transactionID = dateTimeInt + accNumber;
            int[] transResult=emp.Deposit(Convert.ToInt32(accNumber),Convert.ToInt32(txtDepositAmount.Text),transactionID);
            emp.logTransHistory(transactionID, "FromBank", Convert.ToInt32(accNumber), Convert.ToInt32(txtDepositAmount.Text), dateTimeInt, empID, "Credit", transResult[0], transResult[1]);
        }

        private void btnGetAccHolderNameDeposit_Click(object sender, EventArgs e)
        {
            string accNumber = txtDepositAccNum.Text;
            string Name = emp.GetAccountHolderName(Convert.ToInt32(accNumber));
            MessageBox.Show("Pleas Verify You are depositing into Mr. " + Name + " 's Account");
        }

        private void btnClearEntries_Click(object sender, EventArgs e)
        {
            txtAadhar.Text = "";
            txtAmount.Text = "";
            txtDepositAccNum.Text = "";
            txtDepositAmount.Text = "";
            txtFirstName.Text = "";
            txtIFSC.Text = "";
            txtLastName.Text = "";
            txtMobile.Text = "";
            txtWithDrawAccountNumber.Text = "";
            txtWithDrawAmount.Text = "";
        }
    }
}
