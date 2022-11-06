using EmployeeForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bank_Accounts
{
    public partial class frmEmployeeLogin : Form
    {
        public static frmEmployeeLogin form1;
        public frmEmployeeLogin()
        {
            InitializeComponent();
            form1=this;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username=txtUserName.Text;
            string password=txtPassword.Text;

            EmployeeActions empSess=new EmployeeActions();
            int loginAttemptResult=empSess.LoginEmployee(username,password);
            if (loginAttemptResult != 0)
            {
                frmEmployeeActionsPage frmManageAccounts=new frmEmployeeActionsPage(loginAttemptResult);
                this.Hide();
                frmManageAccounts.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EmployeeDBContext empDB = new EmployeeDBContext();
            //Employee emp = new Employee();
            //BankAccountDBContext accDB=new BankAccountDBContext();
            //Account acc = new Account();

            BankBalanceDBContext bankBalanceDB =   new BankBalanceDBContext();
            BankBalanceClass bankBalance=new BankBalanceClass();
        }
    }
}
