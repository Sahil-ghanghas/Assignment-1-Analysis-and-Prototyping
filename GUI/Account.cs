using System;
using System.Collections.Generic;

namespace GUI
{
    // Abstract base class for all account types
    public abstract class Account
    {
        protected decimal balance;
        protected string accountName;
        protected string lastTransactionStatus;
        protected List<string> transactionHistory;

        public Account(string name, decimal initialBalance)
        {
            accountName = name;
            balance = initialBalance;
            lastTransactionStatus = "Account Created";
            transactionHistory = new List<string>();
            transactionHistory.Add($"Account opened with balance: ${balance}");
        }

        // Properties
        public decimal Balance
        {
            get { return balance; }
        }

        public string AccountName
        {
            get { return accountName; }
        }

        public string LastTransactionStatus
        {
            get { return lastTransactionStatus; }
        }

        public List<string> TransactionHistory
        {
            get { return transactionHistory; }
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
