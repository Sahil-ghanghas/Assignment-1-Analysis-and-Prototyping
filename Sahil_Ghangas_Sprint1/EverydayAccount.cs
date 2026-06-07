using System;

namespace Sahil_Ghangas_Sprint1
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
                lastTransactionStatus = "Deposit Failed - Invalid Amount";
                return false;
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
                lastTransactionStatus = "Withdrawal Failed - Invalid Amount";
                return false;
            }

            if (balance < amount)
            {
                lastTransactionStatus = "Withdrawal Failed - Insufficient Funds";
                transactionHistory.Add($"Failed Withdrawal: -${amount}, Balance: ${balance}");
                return false;
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
