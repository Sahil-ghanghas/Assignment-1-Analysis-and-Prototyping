using System;
using System.Collections.Generic;
using System.Linq;

namespace GUI
{
    public class CustomerController
    {
        private readonly List<Customer> customers = new List<Customer>();

        public CustomerController()
        {
            customers.Add(new Customer("CUST001", "John Doe", "john@email.com"));
        }

        public List<Customer> GetCustomers()
        {
            return customers.ToList();
        }

        public Customer GetCustomerByNumber(string customerNumber)
        {
            return customers.FirstOrDefault(c => c.CustomerNumber.Equals(customerNumber, StringComparison.OrdinalIgnoreCase));
        }

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

        public void UpdateCustomer(string customerNumber, string name, string contact)
        {
            var customer = GetCustomerByNumber(customerNumber);
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer not found.");
            }

            customer.UpdateDetails(name, contact);
        }

        public void DeleteCustomer(string customerNumber)
        {
            var customer = GetCustomerByNumber(customerNumber);
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer not found.");
            }

            customers.Remove(customer);
        }

        public List<string> GetAccountNames(string customerNumber)
        {
            return GetCustomerOrThrow(customerNumber).Accounts.Select(a => a.AccountName).ToList();
        }

        public decimal GetBalance(string customerNumber, string accountName)
        {
            return GetAccount(customerNumber, accountName).Balance;
        }

        public string GetLastStatus(string customerNumber, string accountName)
        {
            return GetAccount(customerNumber, accountName).LastTransactionStatus;
        }

        public List<string> GetTransactionHistory(string customerNumber, string accountName)
        {
            return new List<string>(GetAccount(customerNumber, accountName).TransactionHistory);
        }

        public void Deposit(string customerNumber, string accountName, decimal amount)
        {
            GetAccount(customerNumber, accountName).Deposit(amount);
        }

        public void Withdraw(string customerNumber, string accountName, decimal amount, UserRole userRole)
        {
            GetAccount(customerNumber, accountName).Withdraw(amount, userRole);
        }

        public void CalculateInterest(string customerNumber, string accountName)
        {
            GetAccount(customerNumber, accountName).CalculateInterest();
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
