using System;
using static System.Console;

namespace WritingFunctions
{
    class Program
    {
        static void TimesTable(byte number)
        {
            Console.WriteLine($"This is the {number} times table: ");

            for (int row = 1; row <= 12; row++)
            {
                Console.WriteLine($"{row} x {number} = {row * number}");
            }
            Console.WriteLine();
        }

        static void RunTimesTable()
        {
            bool isNumber;

            do
            {
                Write("Enter a number between 0 and 255: ");

                isNumber = byte.TryParse(ReadLine(), out byte number);

                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }

            } while (isNumber);



        }


        static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
        {
            decimal rate = 0.0M;

            rate = twoLetterRegionCode switch
            {
                "CH" => 0.08M,
                "DK" => 0.25M,
                "NO" => 0.25M,
                "GB" => 0.2M,
                "FR" => 0.2M,
                "HU" => 0.27M,
                "OR" => 0.0M,
                "AK" => 0.0M,
                "MT" => 0.0M,
                "ND" => 0.05M,
                "WI" => 0.05M,
                "ME" => 0.05M,
                "VA" => 0.05M,
                "CA" => 0.0825M,
                _ => 0.06M
            };

            return amount * rate;
        }

        static void RunCalculateTax()
        {
            Console.WriteLine("Enter an amount: ");
            string amountInText = ReadLine();

            Console.WriteLine("Enter a two-letter region code: ");
            string region = ReadLine();

            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, region);
                Console.WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine("You did not enter a valid amount!");
            }
        }
        /// <summary>
        /// This is used to convered a number to have a suffix.  ie. th or nd
        /// </summary>
        /// <param name="number">Number is a cardianl value e.g. 1,2,3, and so on</param>
        /// <returns>Number as an ordinal value eg 1st, 2nd , 3rd and so on.</returns>
        static string CardinalToOrdinal(int number)
        {
            string suffix = string.Empty;
            string numberAsText = string.Empty;
            Nullable<char> lastDigit;
            numberAsText = number.ToString();
            lastDigit = numberAsText[numberAsText.Length - 1];


            //switch expression
            suffix = number switch
            {
                11 => "th",
                12 => "th",
                13 => "th",
                _ => lastDigit switch
                {
                    '1' => "st",
                    '2' => "nd",
                    '3' => "rd",
                    _ => "th"
                }


            };

            return $"{number}{suffix}";

        }

        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                Console.WriteLine($"{CardinalToOrdinal(number)}");
            }

            Console.WriteLine();
        }

        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number ==1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        static void RunFactorial()
        {
            bool isNumber;

            do
            {
                Console.WriteLine("Enter a number: ");

                isNumber = int.TryParse(ReadLine(), out int number);

                if (isNumber)
                {
                    Console.WriteLine($"{number:N0}! = {Factorial(number):N0}");
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            }
            while (isNumber);
        }

        static void Main(string[] args)
        {
            // RunTimesTable();
            // RunCalculateTax();
            // RunCardinalToOrdinal();
            RunFactorial();
        }
    }
}
