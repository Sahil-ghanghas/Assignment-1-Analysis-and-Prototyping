using System;

namespace GUI
{
    // Everyday Account - No interest, no overdraft, no fees
    public class EverydayAccount : Account
    {
        public EverydayAccount() : base()
        {
        }

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
                lastTransactionStatus = "Withdrawal Failed - Insufficient Funds (Everyday)";
                transactionHistory.Add($"Failed Withdrawal: -${amount}, Balance: ${balance}");
                throw new InsufficientFundsException($"Everyday account withdrawal failed. Requested ${amount:F2}, available ${balance:F2}. No overdraft is allowed on Everyday accounts.");
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
