﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
    // Withdrawal.cs
    // Class Withdrawal represents an ATM withdrawal transaction.
    public class Withdrawal : Transaction
    {
        private decimal amount; // amount to withdraw
        private Keypad keypad; // reference to Keypad
        private CashDispenser cashDispenser; // reference to cash dispenser

        // constant that corresponds to menu option to cancel
        private const int CANCELED = 6;

        // five-parameter constructor
        public Withdrawal(int userAccountNumber, Screen atmScreen,
        BankDatabase atmBankDatabase, Keypad atmKeypad,
        CashDispenser atmCashDispenser)
        : base(userAccountNumber, atmScreen, atmBankDatabase)
        {
            // initialize references to keypad and cash dispenser
            keypad = atmKeypad;
            cashDispenser = atmCashDispenser;
        }

        // perform transaction, overrides Transaction's abstract method
        public override void Execute()
        {
            bool cashDispensed = false; // cash was not dispensed yet

            // transaction was not canceled yet
            bool transactionCanceled = false;

            // loop until cash is dispensed or the user cancels
            do
            {
                // obtain the chosen withdrawal amount from the user
                int selection = DisplayMenuOfAmounts();

                // check whether user chose a withdrawal amount or canceled
                if (selection != CANCELED)
                {
                    // set amount to the selected dollar amount
                    amount = selection;

                    // get available balance of account involved
                    decimal availableBalance =
                    Database.GetAvailableBalance(AccountNumber);

                    // check whether the user has enough money in the account
                    if (amount <= availableBalance)
                    {
                        // check whether the cash dispenser has enough money
                        if (cashDispenser.IsSufficientCashAvailable(amount))
                        {
                            // debit the account to reflect the withdrawal
                            Database.Debit(AccountNumber, amount);

                            cashDispenser.DispenseCash(amount); // dispense cash
                            cashDispensed = true; // cash was dispensed

                            // instruct user to take cash
                            UserScreen.DisplayMessageLine(
                            "\nPlease take your cash from the cash dispenser.");
                        }
                        else // cash dispenser does not have enough cash
                            UserScreen.DisplayMessageLine(
                            "\nInsufficient cash available in the ATM." +
                            "\n\nPlease choose a smaller amount.");
                    }
                    else // not enough money available in user's account
                        UserScreen.DisplayMessageLine(
                        "\nInsufficient cash available in your account." +
                        "\n\nPlease choose a smaller amount.");
                }
                else
                {
                    UserScreen.DisplayMessageLine("\nCanceling transaction...");
                    transactionCanceled = true; // user canceled the transaction
                }
            } while ((!cashDispensed) && (!transactionCanceled));
        }

        // display a menu of withdrawal amounts and the option to cancel;
        // return the chosen amount or 6 if the user chooses to cancel
        private int DisplayMenuOfAmounts()
        {
            int userChoice = 0; // variable to store return value

            // array of amounts to correspond to menu numbers
            int[] amounts = { 0, 20, 40, 60, 100, 200 };

            // loop while no valid choice has been made
            while (userChoice == 0)
            {
                // display the menu
                UserScreen.DisplayMessageLine("\nWithdrawal options:");
                UserScreen.DisplayMessageLine("1 - $20");
                UserScreen.DisplayMessageLine("2 - $40");
                UserScreen.DisplayMessageLine("3 - $60");
                UserScreen.DisplayMessageLine("4 - $100");
                UserScreen.DisplayMessageLine("5 - $200");
                UserScreen.DisplayMessageLine("6 - Cancel transaction");
                UserScreen.DisplayMessage(
                "\nChoose a withdrawal option (1-6): ");

                // get user input through keypad
                int input = keypad.GetInput();

                // determine how to proceed based on the input value
                switch (input)
                {
                    // if the user chose a withdrawal amount (i.e., option
                    // 1, 2, 3, 4, or 5), return the corresponding amount
                    // from the amounts array
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        userChoice = amounts[input]; // save user's choice
                        break;
                    case CANCELED: // the user chose to cancel
                        userChoice = CANCELED; // save user's choice
                        break;
                    default:
                        UserScreen.DisplayMessageLine(
                        "\nInvalid selection. Try again.");
                        break;
                }
            }
            return userChoice;
        }
    }
}