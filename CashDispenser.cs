using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
    // CashDispenser.cs
    // Represents the cash dispenser of the ATM
    public class CashDispenser
    {
        // the default initial number of bills in the cash dispenser
        private const int INITIAL_COUNT = 500;
        private int billCount; // number of $20 bills remaining
                               // parameterless constructor initializes billCount to INITIAL_COUNT
        public CashDispenser()
        {
            billCount = INITIAL_COUNT; // set billCount to INITIAL_COUNT
        }

        // simulates dispensing the specified amount of cash
        public void DispenseCash(decimal amount)
        {
            // number of $20 bills required
            int billsRequired = ((int)amount) / 20;
            billCount -= billsRequired;
        }

        // indicates whether cash dispenser can dispense desired amount
        public bool IsSufficientCashAvailable(decimal amount)
        {
            // number of $20 bills required
            int billsRequired = ((int)amount) / 20;

            // return whether there are enough bills available
            return (billCount >= billsRequired);
        }
    }
}
