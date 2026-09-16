using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GUI
{
    // Abstract base class for all account types
    public abstract class Account
    {
        protected decimal balance;
        protected string accountName;
        protected string lastTransactionStatus;
        protected List<string> transactionHistory;

        // Parameterless constructor for JSON serialization
        protected Account() 
        { 
            transactionHistory = new List<string>();
            lastTransactionStatus = "Account Created";
            accountName = "";
        }

        public Account(string name, decimal initialBalance)
        {
            accountName = name;
            balance = initialBalance;
            lastTransactionStatus = "Account Created";
            transactionHistory = new List<string>();
            transactionHistory.Add($"Account opened with balance: ${balance}");
        }

        // Properties
        [JsonInclude]
        public decimal Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        [JsonInclude]
        public string AccountName
        {
            get { return accountName; }
            protected set { accountName = value; }
        }

        [JsonInclude]
        public string LastTransactionStatus
        {
            get { return lastTransactionStatus; }
            protected set { lastTransactionStatus = value; }
        }

        [JsonInclude]
        public List<string> TransactionHistory
        {
            get { return transactionHistory; }
            protected set { transactionHistory = value; }
        }

        // Abstract methods that child classes must implement
        public abstract bool Deposit(decimal amount);
        public abstract bool Withdraw(decimal amount, UserRole userRole = UserRole.RegularCustomer);
        public abstract void CalculateInterest();

        // Method to get account info
        public virtual string GetAccountInfo()
        {
            return $"Account: {accountName}\nBalance: ${balance}\nLast Transaction: {lastTransactionStatus}";
        }
    }
}
