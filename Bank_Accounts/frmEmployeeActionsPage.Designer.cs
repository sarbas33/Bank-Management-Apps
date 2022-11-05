namespace EmployeeForm
{
    partial class frmEmployeeActionsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetAccountHolderName = new System.Windows.Forms.Button();
            this.txtWithDrawAmount = new System.Windows.Forms.TextBox();
            this.txtWithDrawAccountNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnGetAccHolderNameDeposit = new System.Windows.Forms.Button();
            this.txtDepositAmount = new System.Windows.Forms.TextBox();
            this.txtDepositAccNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblInitialInvestment = new System.Windows.Forms.Label();
            this.lblIFSC = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtAadhar = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtIFSC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearEntries = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(200, 326);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(144, 37);
            this.btnAddAccount.TabIndex = 0;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetAccountHolderName);
            this.groupBox1.Controls.Add(this.txtWithDrawAmount);
            this.groupBox1.Controls.Add(this.txtWithDrawAccountNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnWithdraw);
            this.groupBox1.Location = new System.Drawing.Point(21, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 221);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Withdrawal";
            // 
            // btnGetAccountHolderName
            // 
            this.btnGetAccountHolderName.BackColor = System.Drawing.Color.Red;
            this.btnGetAccountHolderName.Location = new System.Drawing.Point(474, 31);
            this.btnGetAccountHolderName.Name = "btnGetAccountHolderName";
            this.btnGetAccountHolderName.Size = new System.Drawing.Size(108, 47);
            this.btnGetAccountHolderName.TabIndex = 7;
            this.btnGetAccountHolderName.Text = "Get Account Holder\'s Name";
            this.btnGetAccountHolderName.UseVisualStyleBackColor = false;
            this.btnGetAccountHolderName.Click += new System.EventHandler(this.btnGetAccountHolderName_Click);
            // 
            // txtWithDrawAmount
            // 
            this.txtWithDrawAmount.Location = new System.Drawing.Point(191, 69);
            this.txtWithDrawAmount.Name = "txtWithDrawAmount";
            this.txtWithDrawAmount.Size = new System.Drawing.Size(253, 22);
            this.txtWithDrawAmount.TabIndex = 6;
            // 
            // txtWithDrawAccountNumber
            // 
            this.txtWithDrawAccountNumber.Location = new System.Drawing.Point(191, 29);
            this.txtWithDrawAccountNumber.Name = "txtWithDrawAccountNumber";
            this.txtWithDrawAccountNumber.Size = new System.Drawing.Size(253, 22);
            this.txtWithDrawAccountNumber.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(106, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account Number";
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(505, 129);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(144, 60);
            this.btnWithdraw.TabIndex = 0;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeposit);
            this.groupBox2.Controls.Add(this.btnGetAccHolderNameDeposit);
            this.groupBox2.Controls.Add(this.txtDepositAmount);
            this.groupBox2.Controls.Add(this.txtDepositAccNum);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(21, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 240);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deposit";
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(505, 137);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(144, 67);
            this.btnDeposit.TabIndex = 13;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnGetAccHolderNameDeposit
            // 
            this.btnGetAccHolderNameDeposit.BackColor = System.Drawing.Color.Red;
            this.btnGetAccHolderNameDeposit.Location = new System.Drawing.Point(474, 49);
            this.btnGetAccHolderNameDeposit.Name = "btnGetAccHolderNameDeposit";
            this.btnGetAccHolderNameDeposit.Size = new System.Drawing.Size(108, 47);
            this.btnGetAccHolderNameDeposit.TabIndex = 12;
            this.btnGetAccHolderNameDeposit.Text = "Get Account Holder\'s Name";
            this.btnGetAccHolderNameDeposit.UseVisualStyleBackColor = false;
            this.btnGetAccHolderNameDeposit.Click += new System.EventHandler(this.btnGetAccHolderNameDeposit_Click);
            // 
            // txtDepositAmount
            // 
            this.txtDepositAmount.Location = new System.Drawing.Point(191, 89);
            this.txtDepositAmount.Name = "txtDepositAmount";
            this.txtDepositAmount.Size = new System.Drawing.Size(253, 22);
            this.txtDepositAmount.TabIndex = 11;
            // 
            // txtDepositAccNum
            // 
            this.txtDepositAccNum.Location = new System.Drawing.Point(191, 49);
            this.txtDepositAccNum.Name = "txtDepositAccNum";
            this.txtDepositAccNum.Size = new System.Drawing.Size(253, 22);
            this.txtDepositAccNum.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(106, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(38, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Account Number";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(66, 70);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(75, 16);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(69, 109);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(72, 16);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name";
            // 
            // lblInitialInvestment
            // 
            this.lblInitialInvestment.AutoSize = true;
            this.lblInitialInvestment.Location = new System.Drawing.Point(37, 272);
            this.lblInitialInvestment.Name = "lblInitialInvestment";
            this.lblInitialInvestment.Size = new System.Drawing.Size(104, 16);
            this.lblInitialInvestment.TabIndex = 5;
            this.lblInitialInvestment.Text = "Initial Investment";
            // 
            // lblIFSC
            // 
            this.lblIFSC.AutoSize = true;
            this.lblIFSC.Location = new System.Drawing.Point(105, 233);
            this.lblIFSC.Name = "lblIFSC";
            this.lblIFSC.Size = new System.Drawing.Size(36, 16);
            this.lblIFSC.TabIndex = 6;
            this.lblIFSC.Text = "IFSC";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(157, 67);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(187, 22);
            this.txtFirstName.TabIndex = 7;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(157, 103);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(187, 22);
            this.txtLastName.TabIndex = 8;
            // 
            // txtAadhar
            // 
            this.txtAadhar.Location = new System.Drawing.Point(157, 145);
            this.txtAadhar.Name = "txtAadhar";
            this.txtAadhar.Size = new System.Drawing.Size(187, 22);
            this.txtAadhar.TabIndex = 9;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(157, 187);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(187, 22);
            this.txtMobile.TabIndex = 10;
            // 
            // txtIFSC
            // 
            this.txtIFSC.Location = new System.Drawing.Point(157, 227);
            this.txtIFSC.Name = "txtIFSC";
            this.txtIFSC.Size = new System.Drawing.Size(187, 22);
            this.txtIFSC.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Aadhar Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mobile Number:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(157, 269);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(187, 22);
            this.txtAmount.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAmount);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtIFSC);
            this.groupBox3.Controls.Add(this.txtMobile);
            this.groupBox3.Controls.Add(this.txtAadhar);
            this.groupBox3.Controls.Add(this.txtLastName);
            this.groupBox3.Controls.Add(this.txtFirstName);
            this.groupBox3.Controls.Add(this.lblIFSC);
            this.groupBox3.Controls.Add(this.lblInitialInvestment);
            this.groupBox3.Controls.Add(this.lblLastName);
            this.groupBox3.Controls.Add(this.lblFirstName);
            this.groupBox3.Controls.Add(this.btnAddAccount);
            this.groupBox3.Location = new System.Drawing.Point(769, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 393);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add New Account";
            // 
            // btnClearEntries
            // 
            this.btnClearEntries.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnClearEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClearEntries.Location = new System.Drawing.Point(1015, 483);
            this.btnClearEntries.Name = "btnClearEntries";
            this.btnClearEntries.Size = new System.Drawing.Size(130, 74);
            this.btnClearEntries.TabIndex = 16;
            this.btnClearEntries.Text = "Make New Transaction";
            this.btnClearEntries.UseVisualStyleBackColor = false;
            this.btnClearEntries.Click += new System.EventHandler(this.btnClearEntries_Click);
            // 
            // frmEmployeeActionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 587);
            this.Controls.Add(this.btnClearEntries);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEmployeeActionsPage";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageAccounts_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetAccountHolderName;
        private System.Windows.Forms.TextBox txtWithDrawAmount;
        private System.Windows.Forms.TextBox txtWithDrawAccountNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblInitialInvestment;
        private System.Windows.Forms.Label lblIFSC;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtAadhar;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtIFSC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnGetAccHolderNameDeposit;
        private System.Windows.Forms.TextBox txtDepositAmount;
        private System.Windows.Forms.TextBox txtDepositAccNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClearEntries;
    }
}

