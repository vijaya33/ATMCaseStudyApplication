using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
    // Account.cs
    // Class Account represents a bank account.
    public class Account
    {
        private int accountNumber; // account number
        private int pin; // PIN for authentication
        private decimal availableBalance; // available withdrawal amount
        private decimal totalBalance; // funds available + pending deposit

        // four-parameter constructor initializes attributes
        public Account(int theAccountNumber, int thePIN,
        decimal theAvailableBalance, decimal theTotalBalance)
        {
            accountNumber = theAccountNumber;
            pin = thePIN;
            availableBalance = theAvailableBalance;
            totalBalance = theTotalBalance;
        }
        // read-only property that gets the account number
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        // read-only property that gets the available balance
        public decimal AvailableBalance
        {
            get
            {
                return availableBalance;
            }
        }
        // read-only property that gets the total balance
        public decimal TotalBalance
        {
            get
            {
                return totalBalance;
            }
        }
        // determines whether a user-specified PIN matches PIN in Account
        public bool ValidatePIN(int userPIN)
        {
            return (userPIN == pin);
        }
        // credits the account (funds have not yet cleared)
        public void Credit(decimal amount)
        {
            totalBalance += amount; // add to total balance
        }
        // debits the account
        public void Debit(decimal amount)
        {
            availableBalance -= amount; // subtract from available balance
            totalBalance -= amount; // subtract from total balance
        }
    }
}
