using System;
using System.Collections.Generic;

namespace GUI
{
    // Customer class - holds customer info and accounts
    public class Customer
    {
        private string customerNumber;
        private string name;
        private string contactDetails;
        private List<Account> accounts;

        public Customer(string custNumber, string custName, string contact)
        {
            customerNumber = custNumber;
            name = custName;
            contactDetails = contact;
            accounts = new List<Account>();
            
            // Pre-populate with three account types
            accounts.Add(new EverydayAccount("Everyday", 1000));
            accounts.Add(new InvestmentAccount("Investment", 5000, 0.05m));
            accounts.Add(new OmniAccount("Omni", 2000, 0.03m, 500));
        }

        // Properties
        public string CustomerNumber
        {
            get { return customerNumber; }
        }

        public string Name
        {
            get { return name; }
        }

        public string ContactDetails
        {
            get { return contactDetails; }
        }

        public List<Account> Accounts
        {
            get { return accounts; }
        }

        // Add account to customer
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        // Get customer info
        public string GetCustomerInfo()
        {
            return $"Customer Number: {customerNumber}\nName: {name}\nContact: {contactDetails}";
        }
    }
}
