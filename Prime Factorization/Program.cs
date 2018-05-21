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
            List<BigInteger> decomposition = new List<BigInteger>();
            if (CheckIfPrime(number))
                Console.WriteLine("Input number is prime");
            else
            {
                decomposition = Decompose(number);
                Console.Write($"{number}=");
                for (int i = 0; i < decomposition.Count; i++)
                {
                    if (i != decomposition.Count - 1)
                        Console.Write($"{decomposition[i]}*");
                    else
                        Console.WriteLine(decomposition[i]);
                }
            }
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
                    i+=6;
                }
                return true;
            }
        }

        private static BigInteger ValidateInput(string userInputString)
        {
            BigInteger numberOfNumbers = new BigInteger();
            while ((!BigInteger.TryParse(userInputString, out numberOfNumbers)) || (numberOfNumbers <= 0))
            {
                Console.Write("Write correct value:");
                userInputString = Console.ReadLine();
            }
            return numberOfNumbers;
        }

        private static List<BigInteger> Decompose(BigInteger number)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<BigInteger> primeNumbers = new List<BigInteger>();
            List<BigInteger> primes = new List<BigInteger>();
            primes.Add(2);
            BigInteger i = primes.Last<BigInteger>();
            int  nextPrime = 0;
            while (!CheckIfPrime(number))
            {
                if (CheckIfPrime(i) && BigInteger.Remainder(number, i) == 0)
                {
                    if (i > primes.Last<BigInteger>())
                        primes.Add(i);
                    primeNumbers.Add(i);
                    number = BigInteger.Divide(number, i);
                    i = 2;
                }
                else
                {
                    if (nextPrime + 1 > primes.Count)
                        i++;
                    else
                    {
                        i = primes[nextPrime];
                        nextPrime++;
                    }
                }
            }
            primeNumbers.Add(number);
            watch.Stop();
            Console.WriteLine("Calculation time is:{0}ms ({1}s)", watch.ElapsedMilliseconds, watch.ElapsedMilliseconds / 1000);
            return primeNumbers;
        } 

    }
}

