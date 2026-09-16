using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GUI
{
    /// <summary>
    /// Manages the state and operations of all customers and their associated accounts.
    /// Acts as the central controller in the MVC architecture.
    /// </summary>
    public class CustomerController
    {
        private List<Customer> customers = new List<Customer>();

        /// <summary>
        /// Initializes a new instance of the CustomerController class and adds a default customer.
        /// </summary>
        public CustomerController()
        {
            customers.Add(new Customer("CUST001", "John Doe", "john@email.com"));
        }

        /// <summary>
        /// Retrieves the list of all customers.
        /// </summary>
        /// <returns>A new list containing all current customers.</returns>
        public List<Customer> GetCustomers()
        {
            return customers.ToList();
        }

        /// <summary>
        /// Retrieves a customer by their unique customer number.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <returns>The customer object if found; otherwise, null.</returns>
        public Customer GetCustomerByNumber(string customerNumber)
        {
            return customers.FirstOrDefault(c => c.CustomerNumber.Equals(customerNumber, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Adds a new customer to the system.
        /// </summary>
        /// <param name="customerNumber">The unique identifier for the new customer.</param>
        /// <param name="name">The name of the customer.</param>
        /// <param name="contact">The contact details of the customer.</param>
        /// <returns>The newly created customer object.</returns>
        /// <exception cref="InvalidCustomerDataException">Thrown when the customer number already exists.</exception>
        public Customer AddCustomer(string customerNumber, string name, string contact)
        {
            if (GetCustomerByNumber(customerNumber) != null)
            {
                throw new InvalidCustomerDataException("Customer number already exists.");
            }

            var customer = new Customer(customerNumber, name, contact);
            customers.Add(customer);
            return customer;
        }

        /// <summary>
        /// Updates the details of an existing customer.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer to update.</param>
        /// <param name="name">The new name for the customer.</param>
        /// <param name="contact">The new contact details for the customer.</param>
        /// <exception cref="InvalidCustomerDataException">Thrown when the customer is not found.</exception>
        public void UpdateCustomer(string customerNumber, string name, string contact)
        {
            var customer = GetCustomerByNumber(customerNumber);
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer not found.");
            }

            customer.UpdateDetails(name, contact);
        }

        /// <summary>
        /// Deletes a customer from the system.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer to delete.</param>
        /// <exception cref="InvalidCustomerDataException">Thrown when the customer is not found.</exception>
        public void DeleteCustomer(string customerNumber)
        {
            var customer = GetCustomerByNumber(customerNumber);
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer not found.");
            }

            customers.Remove(customer);
        }

        /// <summary>
        /// Retrieves a list of account names associated with a specific customer.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <returns>A list of account names.</returns>
        public List<string> GetAccountNames(string customerNumber)
        {
            return GetCustomerOrThrow(customerNumber).Accounts.Select(a => a.AccountName).ToList();
        }

        /// <summary>
        /// Retrieves the balance of a specific account for a customer.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <param name="accountName">The name of the account.</param>
        /// <returns>The current balance of the account.</returns>
        public decimal GetBalance(string customerNumber, string accountName)
        {
            return GetAccount(customerNumber, accountName).Balance;
        }

        /// <summary>
        /// Retrieves the last transaction status of a specific account for a customer.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <param name="accountName">The name of the account.</param>
        /// <returns>A string describing the last transaction status.</returns>
        public string GetLastStatus(string customerNumber, string accountName)
        {
            return GetAccount(customerNumber, accountName).LastTransactionStatus;
        }

        /// <summary>
        /// Retrieves the transaction history of a specific account for a customer.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <param name="accountName">The name of the account.</param>
        /// <returns>A list of strings representing the transaction history.</returns>
        public List<string> GetTransactionHistory(string customerNumber, string accountName)
        {
            return new List<string>(GetAccount(customerNumber, accountName).TransactionHistory);
        }

        /// <summary>
        /// Deposits a specified amount into a customer's account.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <param name="accountName">The name of the account.</param>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(string customerNumber, string accountName, decimal amount)
        {
            GetAccount(customerNumber, accountName).Deposit(amount);
        }

        /// <summary>
        /// Withdraws a specified amount from a customer's account.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <param name="accountName">The name of the account.</param>
        /// <param name="amount">The amount to withdraw.</param>
        /// <param name="userRole">The role of the user performing the withdrawal (used for fee discounts).</param>
        public void Withdraw(string customerNumber, string accountName, decimal amount, UserRole userRole)
        {
            GetAccount(customerNumber, accountName).Withdraw(amount, userRole);
        }

        /// <summary>
        /// Calculates and applies interest to a customer's account.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <param name="accountName">The name of the account.</param>
        public void CalculateInterest(string customerNumber, string accountName)
        {
            GetAccount(customerNumber, accountName).CalculateInterest();
        }

        /// <summary>
        /// Transfers a specified amount from one account to another for the same customer.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <param name="sourceAccountName">The name of the source account to withdraw from.</param>
        /// <param name="destAccountName">The name of the destination account to deposit to.</param>
        /// <param name="amount">The amount to transfer.</param>
        public void Transfer(string customerNumber, string sourceAccountName, string destAccountName, decimal amount)
        {
            var customer = GetCustomerOrThrow(customerNumber);
            var source = GetAccount(customerNumber, sourceAccountName);
            var dest = GetAccount(customerNumber, destAccountName);

            // Using Withdraw with the customer's role to ensure staff get the 50% discount if the transfer fails due to overdraft fees
            source.Withdraw(amount, customer.Role);
            dest.Deposit(amount);
        }

        /// <summary>
        /// Adds a new account to a specific customer dynamically.
        /// </summary>
        /// <param name="customerNumber">The unique identifier of the customer.</param>
        /// <param name="account">The new account to add.</param>
        public void AddAccount(string customerNumber, Account account)
        {
            var customer = GetCustomerOrThrow(customerNumber);
            customer.AddAccount(account);
        }

        /// <summary>
        /// Saves the entire state of customers and their accounts to a JSON file.
        /// </summary>
        /// <param name="filePath">The file path where the data should be saved.</param>
        public void SaveData(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            options.Converters.Add(new AccountConverter());
            string jsonString = JsonSerializer.Serialize(customers, options);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Loads the entire state of customers and their accounts from a JSON file.
        /// </summary>
        /// <param name="filePath">The file path to load the data from.</param>
        public void LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions();
                options.Converters.Add(new AccountConverter());
                var loadedCustomers = JsonSerializer.Deserialize<List<Customer>>(jsonString, options);
                if (loadedCustomers != null)
                {
                    customers = loadedCustomers;
                }
            }
        }

        private Customer GetCustomerOrThrow(string customerNumber)
        {
            var customer = GetCustomerByNumber(customerNumber);
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer not found.");
            }

            return customer;
        }

        private Account GetAccount(string customerNumber, string accountName)
        {
            var customer = GetCustomerOrThrow(customerNumber);
            var account = customer.Accounts.FirstOrDefault(a => a.AccountName.Equals(accountName, StringComparison.OrdinalIgnoreCase));
            if (account == null)
            {
                throw new InvalidCustomerDataException("Account was not found for the selected customer.");
            }

            return account;
        }
    }
}
