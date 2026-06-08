using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        private Customer customer;
        private Account selectedAccount;

        public Form1()
        {
            InitializeComponent();
            customer = new Customer("CUST001", "John Doe", "john@email.com");
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            comboBoxAccount.Items.Add("Everyday");
            comboBoxAccount.Items.Add("Investment");
            comboBoxAccount.Items.Add("Omni");
            comboBoxAccount.SelectedIndex = 0;
            ShowAccount(0);
        }

        private void comboBoxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAccount(comboBoxAccount.SelectedIndex);
        }

        private void ShowAccount(int index)
        {
            selectedAccount = customer.Accounts[index];
            labelBalanceValue.Text = "$" + selectedAccount.Balance.ToString("F2");
            labelStatus.Text = "Last Status:\r\n" + selectedAccount.LastTransactionStatus;
            RefreshHistory();
        }

        private void RefreshHistory()
        {
            listBoxHistory.Items.Clear();
            foreach (string transaction in selectedAccount.TransactionHistory)
            {
                listBoxHistory.Items.Add(transaction);
            }
        }

        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null) return;

            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Enter valid amount");
                return;
            }

            selectedAccount.Deposit(amount);
            ShowAccount(comboBoxAccount.SelectedIndex);
            textBoxAmount.Clear();
        }

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null) return;

            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Enter valid amount");
                return;
            }

            UserRole role = radioStaff.Checked ? UserRole.BankStaff : UserRole.RegularCustomer;
            selectedAccount.Withdraw(amount, role);
            ShowAccount(comboBoxAccount.SelectedIndex);
            textBoxAmount.Clear();
        }

        private void buttonWithdrawStaff_Click(object sender, EventArgs e)
        {
            if (!radioStaff.Checked)
            {
                MessageBox.Show("Only Bank Staff can use this button. Select 'Bank Staff' above.");
                return;
            }

            if (selectedAccount == null) return;

            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Enter valid amount");
                return;
            }

            selectedAccount.Withdraw(amount, UserRole.BankStaff);
            ShowAccount(comboBoxAccount.SelectedIndex);
            textBoxAmount.Clear();
        }

        private void buttonInterest_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null) return;

            selectedAccount.CalculateInterest();
            ShowAccount(comboBoxAccount.SelectedIndex);
        }
    }
}
