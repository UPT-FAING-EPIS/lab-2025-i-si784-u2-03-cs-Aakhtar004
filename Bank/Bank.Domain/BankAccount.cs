using System;

namespace Bank.Domain
{
    /// <summary>
    /// Represents a bank account with basic debit and credit operations.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Message shown when debit amount exceeds balance.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        /// <summary>
        /// Message shown when debit amount is less than zero.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="customerName">The name of the customer.</param>
        /// <param name="balance">The initial balance.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Gets the current balance.
        /// </summary>
        public double Balance { get { return m_balance; }  }

        /// <summary>
        /// Debits the specified amount from the account.
        /// </summary>
        /// <param name="amount">The amount to debit.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when amount is less than zero or exceeds balance.</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            m_balance -= amount; 
        }

        /// <summary>
        /// Credits the specified amount to the account.
        /// </summary>
        /// <param name="amount">The amount to credit.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when amount is less than zero.</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}