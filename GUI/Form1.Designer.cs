namespace GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelAccountSelect = new System.Windows.Forms.Label();
            this.comboBoxAccount = new System.Windows.Forms.ComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.radioRegular = new System.Windows.Forms.RadioButton();
            this.radioStaff = new System.Windows.Forms.RadioButton();
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelBalanceValue = new System.Windows.Forms.Label();
            this.labelAmountLabel = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.buttonDeposit = new System.Windows.Forms.Button();
            this.buttonWithdraw = new System.Windows.Forms.Button();
            this.buttonWithdrawStaff = new System.Windows.Forms.Button();
            this.buttonInterest = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.buttonAddNewAccount = new System.Windows.Forms.Button();
            this.groupBoxTransfer = new System.Windows.Forms.GroupBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.labelDest = new System.Windows.Forms.Label();
            this.comboBoxDest = new System.Windows.Forms.ComboBox();
            this.labelTransferAmount = new System.Windows.Forms.Label();
            this.textBoxTransferAmount = new System.Windows.Forms.TextBox();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.buttonDeleteCustomer = new System.Windows.Forms.Button();
            this.buttonEditCustomer = new System.Windows.Forms.Button();
            this.buttonAddCustomer = new System.Windows.Forms.Button();
            this.listBoxCustomers = new System.Windows.Forms.ListBox();
            this.labelCustomers = new System.Windows.Forms.Label();
            this.labelHistory = new System.Windows.Forms.Label();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.groupBoxTransfer.SuspendLayout();
            this.SuspendLayout();
            
            // panelLeft - Left Control Panel
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelLeft.Controls.Add(this.labelAccountSelect);
            this.panelLeft.Controls.Add(this.comboBoxAccount);
            this.panelLeft.Controls.Add(this.labelRole);
            this.panelLeft.Controls.Add(this.radioRegular);
            this.panelLeft.Controls.Add(this.radioStaff);
            this.panelLeft.Controls.Add(this.labelBalance);
            this.panelLeft.Controls.Add(this.labelBalanceValue);
            this.panelLeft.Controls.Add(this.labelAmountLabel);
            this.panelLeft.Controls.Add(this.textBoxAmount);
            this.panelLeft.Controls.Add(this.buttonDeposit);
            this.panelLeft.Controls.Add(this.buttonWithdraw);
            this.panelLeft.Controls.Add(this.buttonWithdrawStaff);
            this.panelLeft.Controls.Add(this.buttonInterest);
            this.panelLeft.Controls.Add(this.labelStatus);
            this.panelLeft.Location = new System.Drawing.Point(0, 70);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(280, 500);
            this.panelLeft.TabIndex = 1;
            
            // labelAccountSelect
            this.labelAccountSelect.AutoSize = true;
            this.labelAccountSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelAccountSelect.ForeColor = System.Drawing.Color.FromArgb(15, 32, 66);
            this.labelAccountSelect.Location = new System.Drawing.Point(15, 15);
            this.labelAccountSelect.Name = "labelAccountSelect";
            this.labelAccountSelect.Size = new System.Drawing.Size(120, 15);
            this.labelAccountSelect.TabIndex = 0;
            this.labelAccountSelect.Text = "Select Account:";
            
            // comboBoxAccount
            this.comboBoxAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxAccount.FormattingEnabled = true;
            this.comboBoxAccount.Location = new System.Drawing.Point(15, 35);
            this.comboBoxAccount.Name = "comboBoxAccount";
            this.comboBoxAccount.Size = new System.Drawing.Size(240, 23);
            this.comboBoxAccount.TabIndex = 1;
            this.comboBoxAccount.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccount_SelectedIndexChanged);
            
            // labelRole
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelRole.ForeColor = System.Drawing.Color.FromArgb(15, 32, 66);
            this.labelRole.Location = new System.Drawing.Point(15, 65);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(100, 15);
            this.labelRole.TabIndex = 11;
            this.labelRole.Text = "User Type:";
            
            // radioRegular
            this.radioRegular.AutoSize = true;
            this.radioRegular.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioRegular.Location = new System.Drawing.Point(15, 85);
            this.radioRegular.Name = "radioRegular";
            this.radioRegular.Size = new System.Drawing.Size(120, 19);
            this.radioRegular.TabIndex = 12;
            this.radioRegular.Text = "Regular Customer";
            this.radioRegular.Checked = true;
            this.radioRegular.UseVisualStyleBackColor = true;
            
            // radioStaff
            this.radioStaff.AutoSize = true;
            this.radioStaff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioStaff.Location = new System.Drawing.Point(140, 85);
            this.radioStaff.Name = "radioStaff";
            this.radioStaff.Size = new System.Drawing.Size(90, 19);
            this.radioStaff.TabIndex = 13;
            this.radioStaff.Text = "Bank Staff";
            this.radioStaff.UseVisualStyleBackColor = true;
            
            // labelBalance
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelBalance.Location = new System.Drawing.Point(15, 115);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(60, 15);
            this.labelBalance.TabIndex = 2;
            this.labelBalance.Text = "Balance:";
            
            // labelBalanceValue
            this.labelBalanceValue.AutoSize = true;
            this.labelBalanceValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelBalanceValue.ForeColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.labelBalanceValue.Location = new System.Drawing.Point(15, 133);
            this.labelBalanceValue.Name = "labelBalanceValue";
            this.labelBalanceValue.Size = new System.Drawing.Size(130, 30);
            this.labelBalanceValue.TabIndex = 3;
            this.labelBalanceValue.Text = "$0.00";
            
            // labelAmountLabel
            this.labelAmountLabel.AutoSize = true;
            this.labelAmountLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelAmountLabel.ForeColor = System.Drawing.Color.FromArgb(15, 32, 66);
            this.labelAmountLabel.Location = new System.Drawing.Point(15, 175);
            this.labelAmountLabel.Name = "labelAmountLabel";
            this.labelAmountLabel.Size = new System.Drawing.Size(110, 15);
            this.labelAmountLabel.TabIndex = 4;
            this.labelAmountLabel.Text = "Enter Amount:";
            
            // textBoxAmount
            this.textBoxAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxAmount.Location = new System.Drawing.Point(15, 195);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(240, 27);
            this.textBoxAmount.TabIndex = 5;
            this.textBoxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
            // buttonDeposit
            this.buttonDeposit.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.buttonDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeposit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonDeposit.ForeColor = System.Drawing.Color.White;
            this.buttonDeposit.Location = new System.Drawing.Point(15, 235);
            this.buttonDeposit.Name = "buttonDeposit";
            this.buttonDeposit.Size = new System.Drawing.Size(110, 35);
            this.buttonDeposit.TabIndex = 6;
            this.buttonDeposit.Text = "Deposit";
            this.buttonDeposit.UseVisualStyleBackColor = false;
            this.buttonDeposit.Click += new System.EventHandler(this.buttonDeposit_Click);
            
            // buttonWithdraw
            this.buttonWithdraw.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.buttonWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWithdraw.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonWithdraw.ForeColor = System.Drawing.Color.White;
            this.buttonWithdraw.Location = new System.Drawing.Point(145, 235);
            this.buttonWithdraw.Name = "buttonWithdraw";
            this.buttonWithdraw.Size = new System.Drawing.Size(110, 35);
            this.buttonWithdraw.TabIndex = 7;
            this.buttonWithdraw.Text = "Withdraw";
            this.buttonWithdraw.UseVisualStyleBackColor = false;
            this.buttonWithdraw.Click += new System.EventHandler(this.buttonWithdraw_Click);
            
            // buttonWithdrawStaff
            this.buttonWithdrawStaff.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.buttonWithdrawStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWithdrawStaff.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.buttonWithdrawStaff.ForeColor = System.Drawing.Color.White;
            this.buttonWithdrawStaff.Location = new System.Drawing.Point(15, 280);
            this.buttonWithdrawStaff.Name = "buttonWithdrawStaff";
            this.buttonWithdrawStaff.Size = new System.Drawing.Size(240, 30);
            this.buttonWithdrawStaff.TabIndex = 8;
            this.buttonWithdrawStaff.Text = "Staff Only: Withdraw (50% Fee Discount)";
            this.buttonWithdrawStaff.UseVisualStyleBackColor = false;
            this.buttonWithdrawStaff.Click += new System.EventHandler(this.buttonWithdrawStaff_Click);
            
            // buttonInterest
            this.buttonInterest.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.buttonInterest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInterest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonInterest.ForeColor = System.Drawing.Color.White;
            this.buttonInterest.Location = new System.Drawing.Point(15, 320);
            this.buttonInterest.Name = "buttonInterest";
            this.buttonInterest.Size = new System.Drawing.Size(240, 35);
            this.buttonInterest.TabIndex = 9;
            this.buttonInterest.Text = "Calculate Interest";
            this.buttonInterest.UseVisualStyleBackColor = false;
            this.buttonInterest.Click += new System.EventHandler(this.buttonInterest_Click);
            
            // labelStatus
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.labelStatus.Location = new System.Drawing.Point(15, 370);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(200, 130);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Last Status:\r\nReady to process transactions";
            
            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.buttonAddNewAccount);
            this.panelRight.Controls.Add(this.groupBoxTransfer);
            this.panelRight.Controls.Add(this.buttonDeleteCustomer);
            this.panelRight.Controls.Add(this.buttonEditCustomer);
            this.panelRight.Controls.Add(this.buttonAddCustomer);
            this.panelRight.Controls.Add(this.listBoxCustomers);
            this.panelRight.Controls.Add(this.labelCustomers);
            this.panelRight.Controls.Add(this.labelHistory);
            this.panelRight.Controls.Add(this.listBoxHistory);
            this.panelRight.Location = new System.Drawing.Point(290, 80);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(540, 480);
            this.panelRight.TabIndex = 2;
            
            // buttonAddNewAccount
            this.buttonAddNewAccount.BackColor = System.Drawing.Color.DarkOrchid;
            this.buttonAddNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddNewAccount.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.buttonAddNewAccount.ForeColor = System.Drawing.Color.White;
            this.buttonAddNewAccount.Location = new System.Drawing.Point(385, 152);
            this.buttonAddNewAccount.Name = "buttonAddNewAccount";
            this.buttonAddNewAccount.Size = new System.Drawing.Size(140, 28);
            this.buttonAddNewAccount.TabIndex = 7;
            this.buttonAddNewAccount.Text = "Add New Account";
            this.buttonAddNewAccount.UseVisualStyleBackColor = false;
            this.buttonAddNewAccount.Click += new System.EventHandler(this.buttonAddNewAccount_Click);
            
            // groupBoxTransfer
            this.groupBoxTransfer.Controls.Add(this.labelSource);
            this.groupBoxTransfer.Controls.Add(this.comboBoxSource);
            this.groupBoxTransfer.Controls.Add(this.labelDest);
            this.groupBoxTransfer.Controls.Add(this.comboBoxDest);
            this.groupBoxTransfer.Controls.Add(this.labelTransferAmount);
            this.groupBoxTransfer.Controls.Add(this.textBoxTransferAmount);
            this.groupBoxTransfer.Controls.Add(this.buttonTransfer);
            this.groupBoxTransfer.Location = new System.Drawing.Point(15, 200);
            this.groupBoxTransfer.Name = "groupBoxTransfer";
            this.groupBoxTransfer.Size = new System.Drawing.Size(510, 70);
            this.groupBoxTransfer.TabIndex = 8;
            this.groupBoxTransfer.TabStop = false;
            this.groupBoxTransfer.Text = "Intra-Account Transfer";
            
            // labelSource
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(10, 25);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(46, 15);
            this.labelSource.TabIndex = 0;
            this.labelSource.Text = "Source:";
            
            // comboBoxSource
            this.comboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.Location = new System.Drawing.Point(60, 22);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(110, 23);
            this.comboBoxSource.TabIndex = 1;
            
            // labelDest
            this.labelDest.AutoSize = true;
            this.labelDest.Location = new System.Drawing.Point(175, 25);
            this.labelDest.Name = "labelDest";
            this.labelDest.Size = new System.Drawing.Size(34, 15);
            this.labelDest.TabIndex = 2;
            this.labelDest.Text = "Dest:";
            
            // comboBoxDest
            this.comboBoxDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDest.FormattingEnabled = true;
            this.comboBoxDest.Location = new System.Drawing.Point(210, 22);
            this.comboBoxDest.Name = "comboBoxDest";
            this.comboBoxDest.Size = new System.Drawing.Size(110, 23);
            this.comboBoxDest.TabIndex = 3;
            
            // labelTransferAmount
            this.labelTransferAmount.AutoSize = true;
            this.labelTransferAmount.Location = new System.Drawing.Point(325, 25);
            this.labelTransferAmount.Name = "labelTransferAmount";
            this.labelTransferAmount.Size = new System.Drawing.Size(16, 15);
            this.labelTransferAmount.TabIndex = 4;
            this.labelTransferAmount.Text = "$";
            
            // textBoxTransferAmount
            this.textBoxTransferAmount.Location = new System.Drawing.Point(340, 22);
            this.textBoxTransferAmount.Name = "textBoxTransferAmount";
            this.textBoxTransferAmount.Size = new System.Drawing.Size(70, 23);
            this.textBoxTransferAmount.TabIndex = 5;
            
            // buttonTransfer
            this.buttonTransfer.BackColor = System.Drawing.Color.FromArgb(103, 58, 183);
            this.buttonTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTransfer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.buttonTransfer.ForeColor = System.Drawing.Color.White;
            this.buttonTransfer.Location = new System.Drawing.Point(420, 20);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(80, 27);
            this.buttonTransfer.TabIndex = 6;
            this.buttonTransfer.Text = "Transfer";
            this.buttonTransfer.UseVisualStyleBackColor = false;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            
            // buttonDeleteCustomer
            this.buttonDeleteCustomer.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.buttonDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteCustomer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.buttonDeleteCustomer.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteCustomer.Location = new System.Drawing.Point(385, 118);
            this.buttonDeleteCustomer.Name = "buttonDeleteCustomer";
            this.buttonDeleteCustomer.Size = new System.Drawing.Size(140, 28);
            this.buttonDeleteCustomer.TabIndex = 6;
            this.buttonDeleteCustomer.Text = "Delete Customer";
            this.buttonDeleteCustomer.UseVisualStyleBackColor = false;
            this.buttonDeleteCustomer.Click += new System.EventHandler(this.buttonDeleteCustomer_Click);
            
            // buttonEditCustomer
            this.buttonEditCustomer.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.buttonEditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditCustomer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.buttonEditCustomer.ForeColor = System.Drawing.Color.White;
            this.buttonEditCustomer.Location = new System.Drawing.Point(385, 84);
            this.buttonEditCustomer.Name = "buttonEditCustomer";
            this.buttonEditCustomer.Size = new System.Drawing.Size(140, 28);
            this.buttonEditCustomer.TabIndex = 5;
            this.buttonEditCustomer.Text = "Modify Customer";
            this.buttonEditCustomer.UseVisualStyleBackColor = false;
            this.buttonEditCustomer.Click += new System.EventHandler(this.buttonEditCustomer_Click);
            
            // buttonAddCustomer
            this.buttonAddCustomer.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.buttonAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCustomer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.buttonAddCustomer.ForeColor = System.Drawing.Color.White;
            this.buttonAddCustomer.Location = new System.Drawing.Point(385, 50);
            this.buttonAddCustomer.Name = "buttonAddCustomer";
            this.buttonAddCustomer.Size = new System.Drawing.Size(140, 28);
            this.buttonAddCustomer.TabIndex = 4;
            this.buttonAddCustomer.Text = "Add Customer";
            this.buttonAddCustomer.UseVisualStyleBackColor = false;
            this.buttonAddCustomer.Click += new System.EventHandler(this.buttonAddCustomer_Click);
            
            // listBoxCustomers
            this.listBoxCustomers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxCustomers.FormattingEnabled = true;
            this.listBoxCustomers.ItemHeight = 15;
            this.listBoxCustomers.Location = new System.Drawing.Point(15, 50);
            this.listBoxCustomers.Name = "listBoxCustomers";
            this.listBoxCustomers.Size = new System.Drawing.Size(350, 139);
            this.listBoxCustomers.TabIndex = 3;
            this.listBoxCustomers.SelectedIndexChanged += new System.EventHandler(this.listBoxCustomers_SelectedIndexChanged);
            
            // labelCustomers
            this.labelCustomers.AutoSize = true;
            this.labelCustomers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelCustomers.ForeColor = System.Drawing.Color.FromArgb(15, 32, 66);
            this.labelCustomers.Location = new System.Drawing.Point(15, 18);
            this.labelCustomers.Name = "labelCustomers";
            this.labelCustomers.Size = new System.Drawing.Size(139, 20);
            this.labelCustomers.TabIndex = 2;
            this.labelCustomers.Text = "Customer Records";
            
            // labelHistory
            this.labelHistory.AutoSize = true;
            this.labelHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelHistory.ForeColor = System.Drawing.Color.FromArgb(15, 32, 66);
            this.labelHistory.Location = new System.Drawing.Point(15, 275);
            this.labelHistory.Name = "labelHistory";
            this.labelHistory.Size = new System.Drawing.Size(160, 20);
            this.labelHistory.TabIndex = 0;
            this.labelHistory.Text = "Transaction History";
            
            // listBoxHistory
            this.listBoxHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxHistory.Location = new System.Drawing.Point(15, 300);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(510, 169);
            this.listBoxHistory.TabIndex = 1;
            
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 580);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "Form1";
            this.Text = "FinanceHub Banking System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            
            // Since we inherit from BaseForm, we must call base's layout method implicitly, 
            // but we added Controls in code, so we just resume layouts.
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.groupBoxTransfer.ResumeLayout(false);
            this.groupBoxTransfer.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label labelAccountSelect;
        private System.Windows.Forms.ComboBox comboBoxAccount;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.RadioButton radioRegular;
        private System.Windows.Forms.RadioButton radioStaff;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label labelBalanceValue;
        private System.Windows.Forms.Label labelAmountLabel;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Button buttonDeposit;
        private System.Windows.Forms.Button buttonWithdraw;
        private System.Windows.Forms.Button buttonWithdrawStaff;
        private System.Windows.Forms.Button buttonInterest;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button buttonAddNewAccount;
        private System.Windows.Forms.GroupBox groupBoxTransfer;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.ComboBox comboBoxSource;
        private System.Windows.Forms.Label labelDest;
        private System.Windows.Forms.ComboBox comboBoxDest;
        private System.Windows.Forms.Label labelTransferAmount;
        private System.Windows.Forms.TextBox textBoxTransferAmount;
        private System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.Button buttonDeleteCustomer;
        private System.Windows.Forms.Button buttonEditCustomer;
        private System.Windows.Forms.Button buttonAddCustomer;
        private System.Windows.Forms.ListBox listBoxCustomers;
        private System.Windows.Forms.Label labelCustomers;
        private System.Windows.Forms.Label labelHistory;
        private System.Windows.Forms.ListBox listBoxHistory;
    }
}
