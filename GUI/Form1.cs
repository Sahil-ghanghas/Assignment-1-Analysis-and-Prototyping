using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : BaseForm
    {
        private readonly CustomerController controller;
        private Customer selectedCustomer;

        public Form1()
        {
            InitializeComponent();
            controller = new CustomerController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller.LoadData("bank_data.json");
            LoadCustomers();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.SaveData("bank_data.json");
        }

        private void LoadCustomers()
        {
            listBoxCustomers.Items.Clear();
            List<Customer> customers = controller.GetCustomers();
            foreach (Customer customer in customers)
            {
                listBoxCustomers.Items.Add($"{customer.CustomerNumber} - {customer.Name}");
            }

            if (listBoxCustomers.Items.Count > 0)
            {
                listBoxCustomers.SelectedIndex = 0;
            }
            else
            {
                comboBoxAccount.Items.Clear();
                comboBoxSource.Items.Clear();
                comboBoxDest.Items.Clear();
                labelBalanceValue.Text = "$0.00";
                labelStatus.Text = "Last Status:\r\nNo customer selected";
                listBoxHistory.Items.Clear();
                selectedCustomer = null;
            }
        }

        private void LoadAccountsForSelectedCustomer()
        {
            if (selectedCustomer == null)
            {
                return;
            }

            comboBoxAccount.Items.Clear();
            comboBoxSource.Items.Clear();
            comboBoxDest.Items.Clear();

            List<string> accountNames = controller.GetAccountNames(selectedCustomer.CustomerNumber);
            foreach (string accountName in accountNames)
            {
                comboBoxAccount.Items.Add(accountName);
                comboBoxSource.Items.Add(accountName);
                comboBoxDest.Items.Add(accountName);
            }

            if (comboBoxAccount.Items.Count > 0)
            {
                comboBoxAccount.SelectedIndex = 0;
            }
        }

        private void comboBoxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSelectedAccountDisplay();
        }

        private void listBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCustomers.SelectedIndex < 0)
            {
                return;
            }

            selectedCustomer = controller.GetCustomers()[listBoxCustomers.SelectedIndex];
            LoadAccountsForSelectedCustomer();
        }

        private void RefreshSelectedAccountDisplay()
        {
            if (selectedCustomer == null || comboBoxAccount.SelectedIndex < 0)
            {
                return;
            }

            string accountName = comboBoxAccount.SelectedItem.ToString();
            labelBalanceValue.Text = "$" + controller.GetBalance(selectedCustomer.CustomerNumber, accountName).ToString("F2");
            labelStatus.Text = "Last Status:\r\n" + controller.GetLastStatus(selectedCustomer.CustomerNumber, accountName);

            listBoxHistory.Items.Clear();
            foreach (string transaction in controller.GetTransactionHistory(selectedCustomer.CustomerNumber, accountName))
            {
                listBoxHistory.Items.Add(transaction);
            }
        }

        private bool TryGetAmount(out decimal amount, TextBox textBox)
        {
            amount = 0m;
            if (!decimal.TryParse(textBox.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Enter valid amount", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool HasSelectedContext()
        {
            return selectedCustomer != null && comboBoxAccount.SelectedIndex >= 0;
        }

        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            if (!HasSelectedContext() || !TryGetAmount(out decimal amount, textBoxAmount)) return;

            try
            {
                controller.Deposit(selectedCustomer.CustomerNumber, comboBoxAccount.SelectedItem.ToString(), amount);
                RefreshSelectedAccountDisplay();
                textBoxAmount.Clear();
            }
            catch (BankingException ex)
            {
                MessageBox.Show(ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            if (!HasSelectedContext() || !TryGetAmount(out decimal amount, textBoxAmount)) return;

            try
            {
                UserRole role = radioStaff.Checked ? UserRole.BankStaff : UserRole.RegularCustomer;
                controller.Withdraw(selectedCustomer.CustomerNumber, comboBoxAccount.SelectedItem.ToString(), amount, role);
                RefreshSelectedAccountDisplay();
                textBoxAmount.Clear();
            }
            catch (BankingException ex)
            {
                RefreshSelectedAccountDisplay();
                MessageBox.Show(ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWithdrawStaff_Click(object sender, EventArgs e)
        {
            if (!radioStaff.Checked)
            {
                MessageBox.Show("Only Bank Staff can use this button. Select 'Bank Staff' above.");
                return;
            }

            if (!HasSelectedContext() || !TryGetAmount(out decimal amount, textBoxAmount)) return;

            try
            {
                controller.Withdraw(selectedCustomer.CustomerNumber, comboBoxAccount.SelectedItem.ToString(), amount, UserRole.BankStaff);
                RefreshSelectedAccountDisplay();
                textBoxAmount.Clear();
            }
            catch (BankingException ex)
            {
                RefreshSelectedAccountDisplay();
                MessageBox.Show(ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInterest_Click(object sender, EventArgs e)
        {
            if (!HasSelectedContext()) return;
            controller.CalculateInterest(selectedCustomer.CustomerNumber, comboBoxAccount.SelectedItem.ToString());
            RefreshSelectedAccountDisplay();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null || comboBoxSource.SelectedIndex < 0 || comboBoxDest.SelectedIndex < 0)
            {
                MessageBox.Show("Select source and destination accounts.", "Validation");
                return;
            }

            if (comboBoxSource.SelectedIndex == comboBoxDest.SelectedIndex)
            {
                MessageBox.Show("Source and destination accounts must be different.", "Validation");
                return;
            }

            if (!TryGetAmount(out decimal amount, textBoxTransferAmount)) return;

            try
            {
                string src = comboBoxSource.SelectedItem.ToString();
                string dest = comboBoxDest.SelectedItem.ToString();
                
                // Temporary role swap just for testing staff transfer fee if staff is selected
                if (radioStaff.Checked) selectedCustomer.Role = UserRole.BankStaff;
                else selectedCustomer.Role = UserRole.RegularCustomer;

                controller.Transfer(selectedCustomer.CustomerNumber, src, dest, amount);
                RefreshSelectedAccountDisplay();
                textBoxTransferAmount.Clear();
                MessageBox.Show("Transfer Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (BankingException ex)
            {
                RefreshSelectedAccountDisplay();
                MessageBox.Show(ex.Message, "Transfer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddNewAccount_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null) return;
            
            // Simple prompt for account creation (could use a dedicated form but a quick MessageBox-like choice is okay, 
            // since we need to select an account type. We will just add an Everyday account by default, or maybe prompt).
            // For simplicity, let's just add an Everyday Account named "Everyday #"
            int count = selectedCustomer.Accounts.Count + 1;
            controller.AddAccount(selectedCustomer.CustomerNumber, new EverydayAccount($"Everyday {count}", 0));
            LoadAccountsForSelectedCustomer();
            MessageBox.Show($"New Everyday Account Added!", "Success");
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            using (var editor = new CustomerEditorForm("Add Customer"))
            {
                if (editor.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    Customer created = controller.AddCustomer(editor.CustomerNumberValue, editor.CustomerNameValue, editor.CustomerContactValue);
                    LoadCustomers();
                    SelectCustomer(created.CustomerNumber);
                }
                catch (BankingException ex)
                {
                    MessageBox.Show(ex.Message, "Customer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonEditCustomer_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null) return;
            using (var editor = new CustomerEditorForm("Modify Customer", selectedCustomer))
            {
                if (editor.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    controller.UpdateCustomer(selectedCustomer.CustomerNumber, editor.CustomerNameValue, editor.CustomerContactValue);
                    LoadCustomers();
                    SelectCustomer(selectedCustomer.CustomerNumber);
                }
                catch (BankingException ex)
                {
                    MessageBox.Show(ex.Message, "Customer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null) return;

            DialogResult confirm = MessageBox.Show(
                $"Delete customer {selectedCustomer.CustomerNumber} - {selectedCustomer.Name}?",
                "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                controller.DeleteCustomer(selectedCustomer.CustomerNumber);
                selectedCustomer = null;
                LoadCustomers();
            }
            catch (BankingException ex)
            {
                MessageBox.Show(ex.Message, "Customer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectCustomer(string customerNumber)
        {
            List<Customer> customers = controller.GetCustomers();
            int selectedIndex = customers.FindIndex(c => c.CustomerNumber.Equals(customerNumber, StringComparison.OrdinalIgnoreCase));
            if (selectedIndex >= 0)
            {
                listBoxCustomers.SelectedIndex = selectedIndex;
            }
        }
    }
}
