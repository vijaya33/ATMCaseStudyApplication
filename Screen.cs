using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
    public class Screen
    {        
         // displays a message without a terminating carriage return
         public void DisplayMessage(string message)
         {
             Console.Write(message);
         }
         // display a message with a terminating carriage return
         public void DisplayMessageLine(string message)
         {
            Console.WriteLine(message);
         }
         // display a dollar amount
         public void DisplayDollarAmount(decimal amount)
         {
             Console.Write("{0:C}", amount);
         }
     }
}

