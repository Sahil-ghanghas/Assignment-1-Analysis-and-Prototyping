using System;

namespace GUI
{
    // Everyday Account - No interest, no overdraft, no fees
    public class EverydayAccount : Account
    {
        public EverydayAccount(string name, decimal initialBalance) 
            : base(name, initialBalance)
        {
        }

        public override bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidTransactionException("Deposit amount must be greater than zero.");
            }

            balance += amount;
            lastTransactionStatus = $"Deposit Successful: +${amount}";
            transactionHistory.Add($"Deposit: +${amount}, New Balance: ${balance}");
            return true;
        }

        public override bool Withdraw(decimal amount, UserRole userRole = UserRole.RegularCustomer)
        {
            if (amount <= 0)
            {
                throw new InvalidTransactionException("Withdrawal amount must be greater than zero.");
            }

            if (balance < amount)
            {
                throw new InsufficientFundsException("Withdrawal failed due to insufficient funds.");
            }

            balance -= amount;
            lastTransactionStatus = $"Withdrawal Successful: -${amount}";
            transactionHistory.Add($"Withdrawal: -${amount}, New Balance: ${balance}");
            return true;
        }

        public override void CalculateInterest()
        {
            // No interest for everyday account
            lastTransactionStatus = "No Interest - Everyday Account";
        }

        public override string GetAccountInfo()
        {
            return $"[EVERYDAY ACCOUNT]\n{base.GetAccountInfo()}\n(No Interest, No Overdraft)";
        }
    }
}
