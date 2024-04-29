using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
     // BankDatabase.cs
     // Represents the bank account information database
     public class BankDatabase
     {
        private Account[] accounts; // array of the bank's Accounts

     // parameterless constructor initializes accounts
     public BankDatabase()
     {
         // create two Account objects for testing and
         // place them in the accounts array
         accounts = new Account[5]; // create accounts array
         accounts[0] = new Account(11111, 1234, 1000.00M, 1200.00M);
         accounts[1] = new Account(22222, 2345, 200.00M, 200.00M);
            accounts[2] = new Account(33333, 1100, 99.00M, 135.00M);
            accounts[3] = new Account(44444, 9089, 200.00M, 200.00M);
            accounts[4] = new Account(66666, 3355, 125000.00M, 135000.00M);

            List<Account> ValidAccounts = new List<Account>();
           ValidAccounts.Add(accounts[0]);
            ValidAccounts.Add(accounts[1]); 
            ValidAccounts.Add(accounts[2]);
            ValidAccounts.Add(accounts[3]);
            ValidAccounts.Add(accounts[4]);
        }
     

    // retrieve Account object containing specified account number
     private Account GetAccount(int accountNumber)
     {
         // loop through accounts searching for matching account number
         foreach (Account currentAccount in accounts)
             {
             if (currentAccount.AccountNumber == accountNumber)
                 return currentAccount;
             }    
        // account not found
        return null;
     }

     // determine whether user-specified account number and PIN match
     // those of an account in the database
     public bool AuthenticateUser(int userAccountNumber, int userPIN)
     {
         // attempt to retrieve the account with the account number
            Account userAccount = GetAccount(userAccountNumber);

            // if account exists, return result of Account function ValidatePIN
            if (userAccount != null)
            {
                return userAccount.ValidatePIN(userPIN); // true if match
            }
            else
            {
                return false; // account number not found, so return false
            }
     }

        // return available balance of Account with specified account numbe
     public decimal GetAvailableBalance(int userAccountNumber)
     {
         Account userAccount = GetAccount(userAccountNumber);
         return userAccount.AvailableBalance;
     }

        // return total balance of Account with specified account number
     public decimal GetTotalBalance(int userAccountNumber)
     {
         Account userAccount = GetAccount(userAccountNumber);
         return userAccount.TotalBalance;
     }

     // credit the Account with specified account number
     public void Credit(int userAccountNumber, decimal amount)
     {
         Account userAccount = GetAccount(userAccountNumber);
         userAccount.Credit(amount);
     }

    // debit the Account with specified account number
     public void Debit(int userAccountNumber, decimal amount)
     {
         Account userAccount = GetAccount(userAccountNumber);
         userAccount.Debit(amount);
     }
 }

}