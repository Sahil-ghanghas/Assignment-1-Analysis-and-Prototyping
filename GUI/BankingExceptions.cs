using System;

namespace GUI
{
    public class BankingException : Exception
    {
        public BankingException(string message) : base(message)
        {
        }
    }

    public class InvalidTransactionException : BankingException
    {
        public InvalidTransactionException(string message) : base(message)
        {
        }
    }

    public class InsufficientFundsException : BankingException
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }

    public class InvalidCustomerDataException : BankingException
    {
        public InvalidCustomerDataException(string message) : base(message)
        {
        }
    }
}
