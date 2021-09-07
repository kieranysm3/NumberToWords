using System;


namespace StringToDollar
{
    
    class MainProgram
    {
        static void Main(string[] args)
            //Main program to get User input(String) which will be converted Decimal and checked for validity. It then calls the CurrencyToWordLibrary methods for conversion.
        {
            bool endApp = false;
            Console.WriteLine("Kieran's English Currency Converter\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string numInput1 = "";
                string result;

                // Ask the user to type the value he wants converted
                Console.Write("Hi there please input the number you want converted to currency: ");
                numInput1 = Console.ReadLine();

                decimal cleanNum1 = 0;
                while (!decimal.TryParse(numInput1, out cleanNum1))
                {
                    //Check that number is set to a valid integer value
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                try
                {
                    decimal convertedString = Convert.ToDecimal(numInput1);
                    result = CurrencyToWordLibrary.CurrencyConverter.CurrencyConversion(convertedString);

                    if (convertedString == 0)
                    {
                        Console.WriteLine("The number in currency fomat is Zero");
                    }
                    else
                    {
                        Console.WriteLine("The number in currency fomat is: \n{0}", result);
                        //uncomment these for test cases
                        /*
                        decimal TestValue1 = 1.255m;
                        Console.WriteLine("Test1 Result = ");
                        Console.WriteLine(CurrencyToWordLibrary.CurrencyConverter.CurrencyConversion(TestValue1)); 
                        
                        decimal TestValue2 = 100000m;
                        Console.WriteLine("Test1 Result = ");
                        Console.WriteLine(CurrencyToWordLibrary.CurrencyConverter.CurrencyConversion(TestValue2)); 

                        decimal TestValue3 = 2.01m;
                        Console.WriteLine("Test1 Result = ");
                        Console.WriteLine(CurrencyToWordLibrary.CurrencyConverter.CurrencyConversion(TestValue3)); 
                        */
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;
                Console.WriteLine("\n");

            }
            return;
        }
    }
}
