using System;

namespace GUI
{
    // Investment Account - Variable interest, failure fee, no overdraft
    public class InvestmentAccount : Account
    {
        private decimal interestRate;
        private decimal failureFee;

        public InvestmentAccount(string name, decimal initialBalance, decimal rate) 
            : base(name, initialBalance)
        {
            interestRate = rate; // e.g., 0.05 for 5%
            failureFee = 10; // $10 fee for failed transaction
        }

        public decimal InterestRate
        {
            get { return interestRate; }
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

            // No overdraft allowed - must have enough funds
            if (balance < amount)
            {
                decimal actualFee = failureFee;
                // Apply 50% discount for bank staff
                if (userRole == UserRole.BankStaff)
                {
                    actualFee = failureFee * 0.5m;
                }
                
                balance -= actualFee;
                lastTransactionStatus = $"Withdrawal Failed - Insufficient Funds. Fee Applied: -${actualFee:F2}";
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
            decimal interest = balance * interestRate;
            balance += interest;
            lastTransactionStatus = $"Interest Calculated: +${interest:F2}";
            transactionHistory.Add($"Interest Applied: +${interest:F2}, New Balance: ${balance}");
        }

        public override string GetAccountInfo()
        {
            return $"[INVESTMENT ACCOUNT]\n{base.GetAccountInfo()}\nInterest Rate: {interestRate * 100}%\n(No Overdraft, Fee on Failed Withdrawal)";
        }
    }
}
