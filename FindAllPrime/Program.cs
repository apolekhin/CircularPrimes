using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllCircularPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primes = new List<int>();
            List<int> circularPrimes = new List<int>();
            
            primes = GetAllPrimes(1000000);
            circularPrimes = GetAllCircularPrimes(primes);

            Console.WriteLine("There are {0} circular primes below 1 000 000", circularPrimes.Count);
            Console.ReadLine();
        }
        
        /*-----------------------------------------------------------------
         * Finds all prime numbers < n, using Sieve of Eratosthenes method. 
         * Resulting list has all non-prime numbers zeroed, 
         * and prime numbers matching their index.*/
        
        public static List<int> GetAllPrimes(int n)
        {
            List<int> arr = new List<int>();
            int m = (int)Math.Sqrt(n);

            for (int i = 0; i < n; i++)
                arr.Add(i);
            
            arr[1] = 0;

            for (int i = 2; i < m; i++ )
                if (arr[i] != 0)
                    for (int j = i * 2; j < n; j+=i )
                        arr[j] = 0;
            return arr;
        }
        
        /*------------------------------------------------------------
         * Returns a list of all circular prime numbers, 
         * by calling IsCircularPrime check on each prime number, 
         * and adding it to the list if it is*/
        
        public static List<int> GetAllCircularPrimes(List<int> primes)
        {
            List<int> circularPrimes = new List<int>();

            foreach (int item in primes)
                if (item != 0 && IsCircularPrime(item, primes))
                    circularPrimes.Add(item);
            
            return circularPrimes;
        }

        public static bool IsPrime(int number, List<int> primes)
        {
            return primes[number] == number;
        }

        /*------------------------------------------------------------------
         * Rotates a number, and checks, if it is contained in primes list*/

        public static bool IsCircularPrime( int number, List<int> primes )
        {
            if (number > 9)
            {
                int digits = GetNumberOfDigits(number);

                for (int i = 0; i < digits - 1; i++)
                {
                    number = (number / 10) + ((number % 10) * ((int)Math.Pow(10, digits - 1)));
                    if (!IsPrime(number, primes))
                        return false;
                }
            }
            return true;
        }

        /*-------------------------------------------
         * Returns the number of digits in a number*/

        public static int GetNumberOfDigits(int number)
        {
            int numdigits = 0;
            do
            {
                number = number / 10;
                numdigits++;
            }
            while (number > 0);
            return numdigits;
        }
    }
}

