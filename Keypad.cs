using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCaseStudyApplication
{
    public class Keypad
     {
        // return an integer value entered by user
         public int GetInput()
         {           
            int input = 0;
            input = int.Parse(Console.ReadLine());
          
            return input;
         }
     }
}
