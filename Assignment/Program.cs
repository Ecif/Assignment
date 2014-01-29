using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Nth number to return ( n <= 1500 && n > 0 ).");
            int n = GetInputValue();
            int result = ReturnNthNumber(n, 2, 3, 5);
            Console.WriteLine("The Nth number is : {0}", result);
            Console.ReadLine();

        }

        private static int GetInputValue()
        {
            int n;
            while (true)
            {
                string input = Console.ReadLine(); // Get user input.     
                try
                {
                    n = Convert.ToInt32(input); // Try to convert string into integer.
                    if (n < 1 || n > 1500) throw new Exception();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Cannot convert input to integer. Try again.");                    
                }               
            }
            return n;            
        }

        public static int ReturnNthNumber(int n, params int[] components)
        {
            
            int numberCounter = 0,  // This is the counter which specifies at which valid number we are at.
            rightNumber = 0,  // Last found valid number.
            valueToTest = 1;  // Value to test for validity. 
            while (numberCounter < n) // Loops until numbercounter is less than n.
            {
                if (CheckCompatibility(valueToTest, components))
                {
                    // Increase valid number counter
                    numberCounter++;                    
                    // Tested value, which matches the criteria is stored in rightNumber
                    rightNumber = valueToTest; 
                }
                // Increase testing value by 1.
                valueToTest++; 
            }
            return rightNumber;            

        }

        public static bool CheckCompatibility(int value,params int[] components)
        {
                foreach (int component in components)// Takes each specified component from components.
                {
                        // Get quotient from operation.
                        double quotient = (double)value / component;
                        // Check whether quotient is an integer.
                        if (Math.Abs(quotient % 1) < double.Epsilon)
                        {
                            // Cast double variable to integer
                            int quotientInt = (int)quotient;
                            // return true as quotientInt is 1 or call the method again with new integer value
                            return quotientInt == 1 || CheckCompatibility(quotientInt, components);
                        }          
                }
            return false;            
        }
    }
}
