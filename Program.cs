using System;
using System.Collections.Generic;
using System.IO; 

namespace ATMCaseStudyApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
          //  Console.WriteLine("This is the ATM Case Study Application.");
            Console.WriteLine("Hello banker, Good day to you, Insert Debit card and press any key to continue.");
            Console.ReadKey();
            ATM newATM = new ATM();
            newATM.Run();
        }
    }
}