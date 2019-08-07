using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq; // Implementation of Linq

namespace _1_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.1 Created a new console application, Every console application starts to activity cycle in the method that called Main.

            #region 1.2 Print all numbers from 1 to 100 to the console, in ascending order.

            // Displaying messages on the screen.
            Console.WriteLine("Numbers from 1 to 100 in ascending order"); 
            Console.WriteLine("----------------------------------------");

            for (int i = 1; i <= 100; i++) // i is an variable. In every loop it increases 1 and it stops when it is equal to 100.
            {
                Console.WriteLine("Number: " + i.ToString()); // Displaying numbers in ascending order.
            }

            #endregion

            #region 1.3 Print all numbers from 1 to 100 to the console in descending order.

            // Displaying messages on the screen.
            Console.WriteLine("Numbers from 1 to 100 in descending order");
            Console.WriteLine("----------------------------------------");

            for (int i = 100; i >= 1; i--) // i is an variable. In every loop it decreases 1 and it stops when it is equal to 1.
            {
                Console.WriteLine("Number: " + i.ToString()); // Displaying numbers in descending order.
            }

            #endregion

            #region 1.4 Calculate the sum of numbers from 1 to n
            int sum = Sum(10); // sum of numbers from 1 to 10. it uses the function that is called Sum.
            Console.WriteLine("Result : " + sum.ToString()); // Displaying result.
            #endregion

            #region 1.5 Program two alternative versions of sum
            int sumA = Sum_A(10); // sum of numbers from 1 to 10. it uses the function that is called Sum_A. 
            Console.WriteLine("Result : " + sumA.ToString()); // displaying results

            int sumB = Sum_B(10);  // sum of numbers from 1 to 10. it uses the function that is called Sum_B. 
            Console.WriteLine("Result : " + sumB.ToString()); // displaying results
            #endregion

            Console.ReadKey(); // it makes the console application wait until any key pressed by the user.
        }

        #region Function Sum
        // Sum uses for-loop to calculate the sum of numbers
        public static int Sum(int n)
        {
            int sum = 0; // sum is variable to return in the function.
            for (int i = 1; i <= n; i++) // i is an variable that increases 1 in every loop 
            // and it stops when it is equal to n. it is used to calculate the sum of numbers from 1 to n.
            {
                sum += i; // the sum variable was increased amount of i.
            }
            return sum; // returning the value for function
        }
        #endregion

        #region Function Sum_A
        // Sum_A uses while-loop to calculate the sum of numbers
        public static int Sum_A(int n)
        {
            int sum = 0, counter = 1; // sum is variable to return in the function.
            while(counter <= n){ // counter is variable to calculate the sum of numbers from 1 to n.
                sum += counter; // in every loop, the counter is added to sum.
                counter++; // the counter was one increased
            }
            return sum; // returning the value for function
        }
        #endregion

        #region Function Sum_B
        // Sum_B uses System.Linq library to calculate the sum of numbers
        public static int Sum_B(int n)
        {
            int sum = Enumerable.Range(1, n).Sum(); // sum is variable to return in the function.
            // Enumerable.Range is a function that belongs to System.Linq library and it calculates the sum of numbers from 1 to n.
            return sum; // returning the value for function
        }
        #endregion
    }
}
