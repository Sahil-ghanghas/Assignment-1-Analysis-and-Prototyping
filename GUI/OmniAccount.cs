using System;

namespace GUI
{
    // Omni Account - Interest on balance >$1000, overdraft allowed, failure fee
    public class OmniAccount : Account
    {
        private decimal interestRate;
        private decimal overdraftLimit;
        private decimal failureFee;
        private decimal interestThreshold; // $1000

        public OmniAccount(string name, decimal initialBalance, decimal rate, decimal overdraft) 
            : base(name, initialBalance)
        {
            interestRate = rate; // e.g., 0.03 for 3%
            overdraftLimit = overdraft; // e.g., 500
            failureFee = 15; // $15 fee for failed transaction
            interestThreshold = 1000;
        }

        public decimal InterestRate
        {
            get { return interestRate; }
        }

        public decimal OverdraftLimit
        {
            get { return overdraftLimit; }
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

            // Check if withdrawal exceeds balance + overdraft limit
            decimal availableFunds = balance + overdraftLimit;
            if (amount > availableFunds)
            {
                decimal actualFee = failureFee;
                // Apply 50% discount for bank staff
                if (userRole == UserRole.BankStaff)
                {
                    actualFee = failureFee * 0.5m;
                }
                
                balance -= actualFee;
                lastTransactionStatus = $"Withdrawal Failed - Exceeds Available Funds. Fee Applied: -${actualFee:F2}";
                transactionHistory.Add($"Failed Withdrawal: -${amount}, Fee: -${actualFee:F2}, Balance: ${balance}");
                return false;
            }

            balance -= amount;
            lastTransactionStatus = $"Withdrawal Successful: -${amount}";
            transactionHistory.Add($"Withdrawal: -${amount}, New Balance: ${balance}");
            return true;
        }

        public override void CalculateInterest()
        {
            // Interest only applied if balance exceeds $1000
            if (balance > interestThreshold)
            {
                decimal interest = balance * interestRate;
                balance += interest;
                lastTransactionStatus = $"Interest Calculated: +${interest:F2}";
                transactionHistory.Add($"Interest Applied: +${interest:F2}, New Balance: ${balance}");
            }
            else
            {
                lastTransactionStatus = "No Interest - Balance Below $1000";
            }
        }

        public override string GetAccountInfo()
        {
            return $"[OMNI ACCOUNT]\n{base.GetAccountInfo()}\nInterest Rate: {interestRate * 100}%\nOverdraft Limit: ${overdraftLimit}\n(Interest on balance >$1000)";
        }
    }
}
