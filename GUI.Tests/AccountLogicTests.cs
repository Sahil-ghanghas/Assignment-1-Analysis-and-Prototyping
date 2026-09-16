using GUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GUI.Tests
{
    [TestClass]
    public class AccountLogicTests
    {
        [TestMethod]
        public void Everyday_Deposit_HappyPath_UpdatesBalance()
        {
            var account = new EverydayAccount("Everyday", 1000m);

            var success = account.Deposit(200m);

            Assert.IsTrue(success);
            Assert.AreEqual(1200m, account.Balance);
            Assert.IsTrue(account.LastTransactionStatus.Contains("Deposit Successful"));
        }

        [TestMethod]
        public void Everyday_Withdraw_ExactBalance_Succeeds()
        {
            var account = new EverydayAccount("Everyday", 500m);

            var success = account.Withdraw(500m);

            Assert.IsTrue(success);
            Assert.AreEqual(0m, account.Balance);
        }

        [TestMethod]
        public void Everyday_Withdraw_Zero_ThrowsInvalidTransactionException()
        {
            var account = new EverydayAccount("Everyday", 500m);

            Assert.ThrowsException<InvalidTransactionException>(() => account.Withdraw(0m));
        }

        [TestMethod]
        public void Everyday_Withdraw_OverBalance_ThrowsAccountSpecificMessage()
        {
            var account = new EverydayAccount("Everyday", 500m);

            var ex = Assert.ThrowsException<InsufficientFundsException>(() => account.Withdraw(500.01m));

            StringAssert.Contains(ex.Message, "Everyday account");
            Assert.AreEqual(500m, account.Balance);
        }

        [TestMethod]
        public void Investment_Withdraw_InsufficientFunds_RegularCustomer_AppliesFullFeeAndThrows()
        {
            var account = new InvestmentAccount("Investment", 500m, 0.05m);

            var ex = Assert.ThrowsException<InsufficientFundsException>(() => account.Withdraw(600m, UserRole.RegularCustomer));

            StringAssert.Contains(ex.Message, "Investment account");
            Assert.AreEqual(490m, account.Balance);
            StringAssert.Contains(account.LastTransactionStatus, "Fee Applied: -$10.00");
        }

        [TestMethod]
        public void Investment_Withdraw_InsufficientFunds_BankStaff_AppliesHalfFeeAndThrows()
        {
            var account = new InvestmentAccount("Investment", 500m, 0.05m);

            var ex = Assert.ThrowsException<InsufficientFundsException>(() => account.Withdraw(600m, UserRole.BankStaff));

            StringAssert.Contains(ex.Message, "Investment account");
            Assert.AreEqual(495m, account.Balance);
            StringAssert.Contains(account.LastTransactionStatus, "Fee Applied: -$5.00");
        }

        [TestMethod]
        public void Investment_InterestCalculation_IncreasesBalanceByRate()
        {
            var account = new InvestmentAccount("Investment", 1000m, 0.05m);

            account.CalculateInterest();

            Assert.AreEqual(1050m, account.Balance);
            StringAssert.Contains(account.LastTransactionStatus, "Interest Calculated");
        }

        [TestMethod]
        public void Omni_Withdraw_ExactOverdraftBoundary_Succeeds()
        {
            var account = new OmniAccount("Omni", 2000m, 0.03m, 500m);

            var success = account.Withdraw(2500m, UserRole.RegularCustomer);

            Assert.IsTrue(success);
            Assert.AreEqual(-500m, account.Balance);
        }

        [TestMethod]
        public void Omni_Withdraw_OverOverdraftByPointZeroOne_ThrowsAndAppliesFee()
        {
            var account = new OmniAccount("Omni", 2000m, 0.03m, 500m);

            var ex = Assert.ThrowsException<InsufficientFundsException>(() => account.Withdraw(2500.01m, UserRole.RegularCustomer));

            StringAssert.Contains(ex.Message, "Omni account");
            Assert.AreEqual(1985m, account.Balance);
            StringAssert.Contains(account.LastTransactionStatus, "Fee Applied: -$15.00");
        }

        [TestMethod]
        public void Omni_InterestCalculation_AboveThreshold_AppliesInterest()
        {
            var account = new OmniAccount("Omni", 2000m, 0.03m, 500m);

            account.CalculateInterest();

            Assert.AreEqual(2060m, account.Balance);
            StringAssert.Contains(account.LastTransactionStatus, "Interest Calculated");
        }

        [TestMethod]
        public void Omni_InterestCalculation_BelowThreshold_DoesNotChangeBalance()
        {
            var account = new OmniAccount("Omni", 1000m, 0.03m, 500m);

            account.CalculateInterest();

            Assert.AreEqual(1000m, account.Balance);
            StringAssert.Contains(account.LastTransactionStatus, "No Interest - Balance Below $1000");
        }

        [TestMethod]
        public void BaseClassContract_IsVerifiedThroughConcreteAccounts()
        {
            Account[] accounts =
            {
                new EverydayAccount("Everyday", 100m),
                new InvestmentAccount("Investment", 100m, 0.05m),
                new OmniAccount("Omni", 100m, 0.03m, 50m)
            };

            foreach (var account in accounts)
            {
                var depositResult = account.Deposit(10m);
                Assert.IsTrue(depositResult);
                Assert.IsTrue(account.TransactionHistory.Count >= 2);
                StringAssert.Contains(account.GetAccountInfo(), "Last Transaction");
            }
        }
    }
}
