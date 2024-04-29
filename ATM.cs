using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
        // ATM.cs
    // Represents an automated teller machine.
 public class ATM
 {
 private bool userAuthenticated; // true if user is authenticated
 private int currentAccountNumber; // user's account number
 private Screen screen; // reference to ATM's screen
 private Keypad keypad; // reference to ATM's keypad
 private CashDispenser cashDispenser; // ref to ATM's cash dispenser
 private DepositSlot depositSlot; // reference to ATM's deposit slot
 private BankDatabase bankDatabase; // ref to account info database

 
 // parameterless constructor initializes instance variables
 public ATM()
 {
 userAuthenticated = false; // user is not authenticated to start
 currentAccountNumber = 0; // no current account number to start
 screen = new Screen(); // create screen
 keypad = new Keypad(); // create keypad
 cashDispenser = new CashDispenser(); // create cash dispenser
 depositSlot = new DepositSlot(); // create deposit slot
 bankDatabase = new BankDatabase(); // create account info database
 }

 // start ATM
 public void Run()
 {
    // welcome and authenticate users; perform transactions
 while (true) // infinite loop
                { 
         // loop while user is not yet authenticated
 while (!userAuthenticated)
             {
             screen.DisplayMessageLine("\nWelcome!, your debit card has been accepted.");
             AuthenticateUser(); // authenticate user
             }
        
         PerformTransactions(); // for authenticated user
         userAuthenticated = false; // reset before next ATM session
         currentAccountNumber = 0; // reset before next ATM session
         screen.DisplayMessageLine("\nThank you! Goodbye!");
         }
     }

 // attempt to authenticate user against database
 private void AuthenticateUser()
 {
     // prompt for account number and input it from user
 screen.DisplayMessage("\nPlease enter your account number: ");
     int accountNumber = keypad.GetInput();
    
 // prompt for PIN and input it from user
 screen.DisplayMessage("\nEnter your PIN: ");
     int pin = keypad.GetInput();
    
 // set userAuthenticated to boolean value returned by database
 userAuthenticated =
 bankDatabase.AuthenticateUser(accountNumber, pin);


            // check whether authentication succeeded
            if (userAuthenticated)
            {

                currentAccountNumber = accountNumber; // save user's account #
            }
            else
            {
                screen.DisplayMessageLine(
                "Invalid account number or PIN. Please try again.");
                Console.WriteLine();
                screen.DisplayMessageLine("*******************************************************************");
                Console.WriteLine(); 
            }
 }

 // display the main menu and perform transactions
 private void PerformTransactions()
 {
     Transaction currentTransaction; // transaction being processed
     bool userExited = false; // user has not chosen to exit
    
 // loop while user has not chosen exit option
 while (!userExited)
         {
         // show main menu and get user selection
 int mainMenuSelection = DisplayMainMenu();
        
         // decide how to proceed based on user's menu selection
 switch ((MenuOption)mainMenuSelection)
 {
             // user chooses to perform one of three transaction types
 case MenuOption.BALANCE_INQUIRY:
 case MenuOption.WITHDRAWAL:
 case MenuOption.DEPOSIT:
 // initialize as new object of chosen type
 currentTransaction =
 CreateTransaction(mainMenuSelection);
             currentTransaction.Execute(); // execute transaction
             break;
             case MenuOption.EXIT_ATM: // user chose to terminate session
 screen.DisplayMessageLine("\nExiting the system...");
             userExited = true; // this ATM session should end
             break;
             default: // user did not enter an integer from 1-4
 screen.DisplayMessageLine(
 "\nYou did not enter a valid selection. Try again.");
             break;
             }
         }
     }

 // display the main menu and return an input selection
 private int DisplayMainMenu()
 {
     screen.DisplayMessageLine("\nMain menu:");
     screen.DisplayMessageLine("1 - View my balance");
     screen.DisplayMessageLine("2 - Withdraw cash");
     screen.DisplayMessageLine("3 - Deposit funds");
     screen.DisplayMessageLine("4 - Exit\n");
     screen.DisplayMessage("Enter a choice: ");
    
     return keypad.GetInput(); // return user's selection
 }

 // return object of specified Transaction derived class
 private Transaction CreateTransaction(int type)
 {
     Transaction temp = null; // null Transaction reference
    
 // determine which type of Transaction to create
 switch ((MenuOption)type)
 {
         // create new BalanceInquiry transaction
 case MenuOption.BALANCE_INQUIRY:
 temp = new BalanceInquiry(currentAccountNumber,
 screen, bankDatabase);
         break;
         case MenuOption.WITHDRAWAL: // create new Withdrawal transaction
 temp = new Withdrawal(currentAccountNumber, screen, bankDatabase, keypad, cashDispenser);
         break;
         case MenuOption.DEPOSIT: // create new Deposit transaction
 temp = new Deposit(currentAccountNumber, screen,
 bankDatabase, keypad, depositSlot);
         break;
         }
    
 return temp;
     }
    }

    // enumeration that represents main menu options
    internal enum MenuOption
    {
        BALANCE_INQUIRY = 1,
        WITHDRAWAL = 2,
        DEPOSIT = 3,
        EXIT_ATM = 4
    }
}


