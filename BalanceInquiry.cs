using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
     // Represents a balance inquiry ATM transaction
     public class BalanceInquiry : Transaction
     {
         // five-parameter constructor initializes base class variables
        public BalanceInquiry(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabase) : base(userAccountNumber, atmScreen, atmBankDatabase) 
        {

        }
        // performs transaction; overrides Transaction's abstract method
        public override void Execute()
        {
            // get the available balance for the current user's Account
            decimal availableBalance = Database.GetAvailableBalance(AccountNumber);
    
            // get the total balance for the current user's Account
            decimal totalBalance = Database.GetTotalBalance(AccountNumber);
    
            // display the balance information on the screen
            UserScreen.DisplayMessageLine("\nBalance Information:");
             UserScreen.DisplayMessage(" - Available balance: ");
             UserScreen.DisplayDollarAmount(availableBalance);
             UserScreen.DisplayMessage("\n - Total balance: ");
             UserScreen.DisplayDollarAmount(totalBalance);
             UserScreen.DisplayMessageLine("");
         }
     }
}

