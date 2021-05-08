using System;
using System.Linq;

namespace AbrakDabraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***-Series Start-***");
            var array = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            AbraKaDabra(array); //O(3n) == O(n)
            Console.WriteLine("***-Series End-***");
        }
        static double AbraKaDabra(int[] inputArray) 
        {
            double result = 1;
            int startIndex = inputArray[0];
            var nthTerm = inputArray[inputArray.Length-1];
            if (startIndex > nthTerm)
            {
                Console.WriteLine("Invalid Scenario");
                return 0;
            }

            int multiplier = 1;
           
            while (startIndex <= nthTerm)// O(n)
            {
                int sum = 0;
                for (int index = startIndex; index < startIndex + 3; index++) //3
                {
                    sum += index;
                }

                multiplier *= sum;
                Console.WriteLine(multiplier);
                startIndex++;

                result *= multiplier;
            }
            return result;
        }
    }
}
