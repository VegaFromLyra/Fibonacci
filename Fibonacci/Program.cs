using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static private readonly int MAX = 4000;
        static private int[] fibonacci = new int[MAX];
        static void Main(string[] args)
        {
            int n = 7;
            int[] result = GetNFibonacciNumbers(n);

            Console.WriteLine("{0} Fibonacci numbers are", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("The {0}th Fibonacci number is {1}", n, GetNthFibonacciNumber(n - 1));

            Console.WriteLine("The {0}th Fibonacci number using DP is {1}", n, GetNthFibonacciNumberDP(n - 1));
        }

        // n is 1 indexed
        static int[] GetNFibonacciNumbers(int n)
        {
            int[] result = new int[n];

            if (n > 1)
            {
                result[0] = 1;
                result[1] = 1;

                for (int i = 2; i < n; i++)
                {
                    result[i] = result[i - 1] + result[i - 2];
                }
            }
            else if (n == 1)
            {
                result[0] = 1;
            }

            return result;
        }

        static int GetNthFibonacciNumber(int n)
        {
            // since n is 1 indexed

            if (n < 0)
            {
                throw new Exception("Fibonacci numbers are only present for non negative ints");
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return GetNthFibonacciNumber(n - 1) + GetNthFibonacciNumber(n - 2);
            }
        }

        static int GetNthFibonacciNumberDP(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            if (fibonacci[n] != 0)
            {
                return fibonacci[n];
            }

            fibonacci[n] = GetNthFibonacciNumberDP(n - 1) + GetNthFibonacciNumberDP(n - 2);

            return fibonacci[n];
        }
    }
}
