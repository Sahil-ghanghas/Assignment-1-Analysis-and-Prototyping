using Sahil_Ghangas_Sprint1;

// Create a customer with 3 pre-populated accounts
Customer customer = new Customer("CUST001", "Sahil", "sahil@email.com");

// Get the three accounts
Account everyday = customer.Accounts[0];
Account investment = customer.Accounts[1];
Account omni = customer.Accounts[2];

Console.WriteLine("=== Banking System Demo ===\n");
Console.WriteLine(customer.GetCustomerInfo() + "\n");

// Test Everyday Account
Console.WriteLine("--- EVERYDAY ACCOUNT ---");
Console.WriteLine(everyday.GetAccountInfo());
everyday.Deposit(500);
Console.WriteLine($"After Deposit: {everyday.LastTransactionStatus}");
everyday.Withdraw(200);
Console.WriteLine($"After Withdrawal: {everyday.LastTransactionStatus}");
Console.WriteLine($"Final Balance: ${everyday.Balance}\n");

// Test Investment Account (Regular Customer)
Console.WriteLine("--- INVESTMENT ACCOUNT (Regular Customer) ---");
Console.WriteLine(investment.GetAccountInfo());
investment.Deposit(1000);
Console.WriteLine($"After Deposit: {investment.LastTransactionStatus}");
investment.Withdraw(6000, UserRole.RegularCustomer); // Fails, pays full $10 fee
Console.WriteLine($"Failed Withdrawal (Regular): {investment.LastTransactionStatus}");
Console.WriteLine($"Balance After Fee: ${investment.Balance}\n");

// Test Investment Account (Bank Staff)
Console.WriteLine("--- INVESTMENT ACCOUNT (Bank Staff - 50% Discount) ---");
Account investmentStaff = new InvestmentAccount("Investment-Staff", 5000, 5.0m);
Console.WriteLine(investmentStaff.GetAccountInfo());
investmentStaff.Withdraw(6000, UserRole.BankStaff); // Fails, pays only $5 fee (50% discount)
Console.WriteLine($"Failed Withdrawal (Staff): {investmentStaff.LastTransactionStatus}");
Console.WriteLine($"Balance After Discounted Fee: ${investmentStaff.Balance}\n");

// Test Omni Account
Console.WriteLine("--- OMNI ACCOUNT ---");
Console.WriteLine(omni.GetAccountInfo());
omni.Deposit(1500);
Console.WriteLine($"After Deposit: {omni.LastTransactionStatus}");
omni.CalculateInterest(); // Interest applied (balance > $1000)
Console.WriteLine($"After Interest: {omni.LastTransactionStatus}");
Console.WriteLine($"Final Balance: ${omni.Balance}");
