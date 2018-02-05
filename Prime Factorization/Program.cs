using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Prime_Factorization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a number that you want to decompose:");
            string userInputString = Console.ReadLine();
            BigInteger number = ValidateInput(userInputString);
            Console.WriteLine("Input number is prime:{0}", CheckIfPrime(number));
            Console.ReadLine();
        }

        //from here:https://en.wikipedia.org/wiki/Primality_test
        private static bool CheckIfPrime(BigInteger number)
        {
            if (number <= 3)
                return true;
            else if (BigInteger.Remainder(number, 2) == 0 || BigInteger.Remainder(number, 3) == 0)
                return false;
            else
            {
                BigInteger i = new BigInteger(5);
                while (BigInteger.Pow(i, 2) <= number)
                {
                    if (BigInteger.Remainder(number, i) == 0 || BigInteger.Remainder(number, i + 2) == 0)
                        return false;
                    i++;
                }
                return true;
            }
        }

        private static BigInteger ValidateInput(string userInputString)
        {
            BigInteger numberOfNumbers;
            while ((!BigInteger.TryParse(userInputString, out numberOfNumbers)) || (numberOfNumbers <= 0))
            {
                Console.Write("Write correct value:");
                userInputString = Console.ReadLine();
            }
            return numberOfNumbers;
        }
    }
}
