using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //call the find prime function
            findPrime();

            //call the EvenFibonacciSequencer function
            EvenFibonacciSequencer(1000000);

            //call the LongestCollatzSequence function
            LongestCollatzSequence();

            //keep the console open
            Console.ReadKey();
        }
        //start of functions used to find prime numbers
        static void findPrime()
        {
            Greet();
            bool exit = false;

            while (!exit)
            {
                string inputString = Console.ReadLine();
                if (inputString != "exit" && inputString != "Exit" && inputString != "e" && inputString != "E" && inputString != "")
                {
                    int inputInt = Convert.ToInt32(inputString);
                    int wantPrime = inputInt;
                    Console.WriteLine("\nThe " + inputInt + "th prime number is " + loopCheck(wantPrime));
                    Console.WriteLine("\nType a number to find another prime.\nType 'exit' or 'e' to end program.\n");
                }
                else
                {
                    exit = true;
                }
            }
            Console.WriteLine("Thank you for using the program");
            System.Threading.Thread.Sleep(1500);
        }

        static int loopCheck(int end)
        {
            int primeCount = 4;
            int currentNumCheck = 11;
            while (primeCount < end)
            {
                if (checkPrime(currentNumCheck) == true)
                {
                    primeCount++;
                    //Take out in final version, testing purposes only
                    //Console.WriteLine(currentNumCheck);
                }
                currentNumCheck += 2;
            }
            return (currentNumCheck - 2);
        }

        static bool checkPrime(int number)
        {
            bool mayBePrime = false;
            bool isNotPrime = false;
            bool isPrime = false;
            for (int i = 3; i <= (Math.Floor(Math.Sqrt(number))) && !isNotPrime; i += 2)
            {
                if (number % i == 0)
                {
                    isNotPrime = true;
                }
                else
                {
                    mayBePrime = true;
                }
            }
            isPrime = (mayBePrime && !isNotPrime);
            return isPrime;
        }

        static void Greet()
        {
            Console.WriteLine("What prime do you want?");
            Console.WriteLine("WARNING: Inputs less than 5 will not desplay correct answers.\nWARNING: Inputs over 100,000 may take a long time.");
            Console.WriteLine("Type 'exit' or 'e' to end program.\n");
        }
        //end of functions used to find prime numbers
        
        //function to add even fib nums
        static void EvenFibonacciSequencer(long maxValue)
        {
            //set up list for fibonacci numbers
            List<long> fibList = new List<long> { 1, 2 };
            //build the list of fibonacci numbers to be long enough
            while (fibList.Last() <= maxValue)
            {
                fibList.Add(fibList[fibList.Count - 1] + fibList[fibList.Count - 2]);
                fibList.OrderBy(x => x);
            }
            //add all the even fib nums
            Console.WriteLine(fibList.Where(x => x % 2 == 0).Where(x => x <= maxValue).Sum());
        }

        //function to find longest collatz sequence
        static void LongestCollatzSequence()
        {
            //keep track of the high scores
            long highScoreChain = 1;
            long highScoreNumber = 1;

            //loop through all the numbers less than a million
            for (int i = 1; i <= 1000000; i++)
            {
                long start = i;
                int sequenceLenght = 0;
                //do the sequence on the input number
                while (start != 1)
                {
                    if (start % 2 == 0)
                    {
                        start = start / 2;
                        sequenceLenght += 1;
                    }
                    else
                    {
                        start = (3 * start) + 1;
                        sequenceLenght += 1;
                    }
                }
                //update the high scores if needed
                if (sequenceLenght > highScoreChain)
                {
                    highScoreChain = sequenceLenght;
                    highScoreNumber = i;
                }
            }
            //pring output
            Console.WriteLine("The number " + highScoreNumber + " has the longest chain at " + highScoreChain + " steps.");
        }
    }
}
