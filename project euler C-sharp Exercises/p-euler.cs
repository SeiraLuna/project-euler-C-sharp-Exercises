

//Problem #11 -- Largest Product in a Grid https://projecteuler.net/problem=11
//In the 20×20 grid below, four numbers along a diagonal line have been marked in red.
//The product of these numbers is 26 × 63 × 78 × 14 = 1788696.
//What is the greatest product of four adjacent numbers in the same direction(up, down, left, right, or diagonally) 
//in the 20×20 grid?

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @".\problem 10.txt";
            int[,] numGrid = new int[20,20];
            string nums = "";

            //populates nums string from file
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);

            for (var i = 0; i < 20; i++)
            {
                nums = nums + sr.ReadLine() + " "; //adds space at line-breaks ILO line breaks
            }

            sr.Close();
            fs.Close();

            //tests to confirm nums was populated correctly
            Console.WriteLine(nums);

            //populates numGrid
            Populate(ref numGrid, nums, 0, 0);

            //tests to confirm numGrid was populated correctly
            for(var i = 0; i < 20; i++)
            {
                for (var j = 0; j < 20; j++)
                {
                    Console.Write($"{numGrid[i,j]}, ");
                }
            }


            Console.ReadKey();
        }

        static void Populate(ref int[,] grid, string numbers, int row, int col)
        {
            grid[row, col] = Convert.ToInt32(numbers.Substring(0, 2));
            if (row == 19 && col == 19)
                return;
            if(col == 19)
            {
                row += 1;
                col = -1;
            }
            Populate(ref grid, numbers.Substring(3), row, col + 1);
        }


    }
}


/*
//Problem #10 -- Summation of Primes https://projecteuler.net/problem=10
//The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
//Find the sum of all the primes below two million.

using System;
using System.Collections.Generic;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = new List<int>();

            Console.WriteLine(SumList(ref numList, 2000000));
                        
            Console.ReadKey();
        }

        static bool IsPrime(int num)
        {
            if (num == 1)
                return false;
            if ((num > 2 && num % 2 == 0) || (num > 3 && num % 3 == 0) || (num > 5 && num % 5 == 0))
                return false;
            for (var i = 7; i <= Math.Sqrt(num); i += 2)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    continue;
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        static long SumList (ref List<int> nums, int count)
        {
            long sum = 0;
            for (var i = 1; i <= count; i++)   
            {
                if (IsPrime(i))
                {
                    nums.Add(i);
                    sum += i;
                }
            }
            return sum;
        }
    }
}

/*
//Problem #9 -- Special Pythagorean Triplet https://projecteuler.net/problem=9
//A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
//a2 + b2 = c2
//For example, 32 + 42 = 9 + 16 = 25 = 52.
//There exists exactly one Pythagorean triplet for which a + b + c = 1000.
//Find the product abc.

using System;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumOfThree = 1000;
            PythagoreanTripleFromSum(1000);


            Console.ReadKey();
        }

        static void PythagoreanTripleFromSum(int sum)
        {
            int a = 0, b = 0, c = 0;
            for(int m = 1; (a + b + c) < 1001; m++)
            {
                for(int n = m + 1; (a + b + c) < 1000; n++)
                {
                    a = (n * n) - (m * m);
                    b = 2 * n * m;
                    c = (n * n) + (m * m);
                    Console.WriteLine($"m = {m}, n = {n}: {a} + {b} + {c} = {a + b + c}\t {a} * {b} * {c} = {a*b*c}");
                }
                if ((a + b + c) > 1000)
                {
                    a = 0;
                    b = 0;
                    c = 0;
                }
            }

        }
    }
}


/*
//Problem #8 -- Largest Product in a Series https://projecteuler.net/problem=8
//The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
//Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?

using System;
using System.Collections.Generic;
using System.IO;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            string nums;
            List<int> numList = new List<int>();
            string filepath = @".\problem 7.txt";

            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);            
            nums = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            nums = nums.Replace(System.Environment.NewLine,"");
            
            foreach(char c in nums)
            {
                numList.Add(Convert.ToInt32(Convert.ToString(c)));
            }

            Console.WriteLine(ThirteenGreatestProduct(numList));

            Console.ReadKey();
        }

        static long ThirteenGreatestProduct(List<int> nums)
        {
            long prod = 1;
            for(var i = 0; i < nums.Count-12; i++)
            {
               long  temp = 1;
                for (var j = 0; j < 13; j++)
                {
                    if (nums[i + j] == 0)
                        break;
                    temp = temp * nums[i + j];
                }
                if (temp > prod)
                    prod = temp;
            }
            return prod;
        }
    }
}


/*
//Problem #7 -- 10001st Prime https://projecteuler.net/problem=7
//By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
//What is the 10 001st prime number?

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primeList = new List<int>();

            CountPrimes(ref primeList);
            
            Console.ReadKey();
        }

        static bool IsPrime(int num)
        {
            if ((num > 2 && num % 2 == 0) || (num > 3 && num % 3 == 0) || (num > 5 && num % 5 == 0))
                    return false;    
            for(var i = 7; i <= Math.Sqrt(num); i += 2)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    continue;
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        static void CountPrimes(ref List<int> primes)
        {            
            for(var i = 2; primes.Count < 10001; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                    Console.WriteLine($"{i} is prime number {primes.Count}");
                }
            }
        }
    }
}



/*
//Problem #6 -- Sum Square Difference https://projecteuler.net/problem=6
//The sum of the squares of the first ten natural numbers is,
//12 + 22 + ... + 102 = 385
//The square of the sum of the first ten natural numbers is,
//(1 + 2 + ... + 10)2 = 552 = 3025
//Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
//Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.


using System;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] naturalNums = new int[100];
            for(var i = 0; i < naturalNums.Length; i++)
            {
                naturalNums[i] = i + 1;
            }
            int sumOfSquares = SumSquares(naturalNums);
            Console.WriteLine($"Sum of the squares of the first {naturalNums.Length} natural numbers: {sumOfSquares}");

            int squareOfSums = SquareSum(naturalNums);
            Console.WriteLine($"Square of the sum of the first {naturalNums.Length} natural numbers: {squareOfSums}");

            Console.WriteLine($"Difference between the Sum of Squares and Square of the Sum: {sumOfSquares - squareOfSums}: ");

            Console.ReadKey();
        }

        public static int SumSquares(int[] nums)
        {
            int sum = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                sum += (nums[i] * nums[i]);
            }
            return sum;
        }

        public static int SquareSum(int[] nums)
        {
            int sum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum * sum;
        }
    }
}

/*
//Problem #5 -- Smallest Multiple https://projecteuler.net/problem=5
//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>() { };
            int product = 1;

            Populate(nums);

            for (var i = 0; i < nums.Count; i++)
            {
                product *= nums[i];
            }

            Console.WriteLine(product);
            Console.ReadKey();
        }

        static void Populate(List<int> numlist)
        {
            int temp = 0;
            for (var i = 1; i < 21; i++)
            {
                temp = i;
                for (var j = 0; j < i; j++)
                {
                    if (numlist.Count == 0)
                        numlist.Add(temp);
                    else if (temp % numlist[j] == 0)
                    {
                        temp = temp / numlist[j];
                    }
                }
                numlist.Add(temp);
                Console.WriteLine(string.Join(", ", numlist));
            }

        }
    }
}


/*
//Problem #4 -- Largest Palindrom Product https://projecteuler.net/problem=4
//A palindromic number reads the same both ways. 
//The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
//Find the largest palindrome made from the product of two 3-digit numbers.


using System;
using System.Collections;
using System.Linq;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList pOf3Di = new ArrayList();

            for(var i = 100; i < 1000; i++)
            {
                for (var j = 100; j < 1000; j++)
                {
                    pOf3Di.Add(i * j);
                }
            }

            Console.WriteLine(pOf3Di.Count);
            pOf3Di.Sort();
            
            for (var i = pOf3Di.Count - 1; i >=0; i--)
            {                
                if (IsPalindrome((int)pOf3Di[i]))
                {
                    Console.WriteLine(pOf3Di[i]);
                    break;
                }
            }

            Console.ReadKey();
        }

        static bool IsPalindrome(int num)
        {
            string sNum = Convert.ToString(num);

            while(true)
            {
                if (sNum[0] != sNum[sNum.Length-1])
                    return false;
                if (sNum.Length < 4)
                    return true;
                sNum = sNum.Substring(1, sNum.Length - 2);
            }
        }

    }
}


/*
//Problem #3 -- Largest Prime Factor https://projecteuler.net/problem=3
//The prime factors of 13195 are 5, 7, 13 and 29.
//What is the largest prime factor of the number 600851475143 ?

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = 600851475143;
            Console.WriteLine(LargestPrime(Factor(num)));

            Console.ReadKey();
        }
        static Stack<long> Factor(long num)
        {
            Stack<long> Factors = new Stack<long>();
            for(int i = 1; i < Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                {
                    Console.WriteLine($"{i} x {num / i}");
                    Factors.Push(i);
                    Factors.Push(num / i);
                }
            }
            return Factors;
        }

        static long LargestPrime(Stack<long> num)
        {
            long LPF = 1;
            for(int i = 0; i < num.Count; i++)
            {
                if (Factor(num.Peek()).Count ==2)
                    LPF = num.Pop();
                else num.Pop();
            }
            return LPF;
        }
    }
}


/*
//Problem #2 -- Even Fibonacci numbers https://projecteuler.net/problem=2

//Each new term in the Fibonacci sequence is generated by adding the previous two terms.
//By starting with 1 and 2, the first 10 terms will be: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
//By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
//find the sum of the even-valued terms.

using System;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 4000000;
            Console.WriteLine(fibSum(num));

            Console.ReadKey();
        }

        static int fibSum(int num)
        {
            int sum = 0;
            for (int i = 0, j = 1; i < num; i += j)
            {
                if (i % 2 == 0)
                    sum += i;
                j += i;
                if (j % 2 == 0)
                    sum += j;
            }
            return sum;
        }
    }
}




/*
//Problem #1 -- Multiples of 3 and 5 https://projecteuler.net/problem=1

//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
//The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000. 

using System;
using System.Globalization;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1000;
            int sum = 0;
            for(var i = 1; i < num; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }

            Console.WriteLine(sum);

            Console.ReadKey();
        }
    }
}
*/
