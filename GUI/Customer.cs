using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GUI
{
    public class Customer
    {
        private string customerNumber;
        private string name;
        private string contactDetails;
        private List<Account> accounts;

        public Customer()
        {
            accounts = new List<Account>();
        }

        public Customer(string custNumber, string custName, string contact, UserRole role = UserRole.RegularCustomer)
        {
            if (string.IsNullOrWhiteSpace(custNumber))
            {
                throw new InvalidCustomerDataException("Customer number cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(custName))
            {
                throw new InvalidCustomerDataException("Customer name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(contact))
            {
                throw new InvalidCustomerDataException("Contact details cannot be empty.");
            }

            customerNumber = custNumber;
            name = custName;
            contactDetails = contact;
            accounts = new List<Account>();

            accounts.Add(new EverydayAccount("Everyday", 1000));
            accounts.Add(new InvestmentAccount("Investment", 5000, 0.05m));
            accounts.Add(new OmniAccount("Omni", 2000, 0.03m, 500));
            Role = role;
        }

        public UserRole Role { get; set; }

        [JsonInclude]
        public string CustomerNumber
        {
            get { return customerNumber; }
            protected set { customerNumber = value; }
        }

        [JsonInclude]
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        [JsonInclude]
        public string ContactDetails
        {
            get { return contactDetails; }
            protected set { contactDetails = value; }
        }

        [JsonInclude]
        public List<Account> Accounts
        {
            get { return accounts; }
            protected set { accounts = value; }
        }

        public void AddAccount(Account account)
        {
            if (account == null)
            {
                throw new InvalidCustomerDataException("Account cannot be null.");
            }

            accounts.Add(account);
        }

        public void UpdateDetails(string custName, string contact)
        {
            if (string.IsNullOrWhiteSpace(custName))
            {
                throw new InvalidCustomerDataException("Customer name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(contact))
            {
                throw new InvalidCustomerDataException("Contact details cannot be empty.");
            }

            name = custName;
            contactDetails = contact;
        }

        public string GetCustomerInfo()
        {
            return $"Customer Number: {customerNumber}\nName: {name}\nContact: {contactDetails}";
        }
    }
}
