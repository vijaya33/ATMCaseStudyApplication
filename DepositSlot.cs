using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
    // DepositSlot.cs
    // Represents the deposit slot of the ATM
    public class DepositSlot
    {
        // indicates whether envelope was received (always returns true,
        // because this is only a software simulation of a real deposit slot)
        public bool IsDepositEnvelopeReceived()
        {
            return true; // deposit envelope was received
        }
    }
}
