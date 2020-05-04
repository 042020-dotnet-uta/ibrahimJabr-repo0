using System;

namespace evenMultTa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a number");
            string input = Console.ReadLine();
            int num;
            try
            {
                num = int.Parse(input);
                IsEven(num);
            }
            catch (FormatException)
            {
                Console.WriteLine($"{input} is a string, not a number.");
            }
            Console.WriteLine("enter a number");
            input = Console.ReadLine();
            bool b = true; ;
            while (b)
            {
                try
                {
                    num = int.Parse(input);
                    if(num > 0) 
                    {
                        MultTable(num);
                        b = false;
                    }
                    else 
                    {
                        Console.WriteLine($"{num} is less than one, re-enter the number");
                        input = Console.ReadLine();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{input} is a string, not a number, re-enter the number");
                    input = Console.ReadLine();
                }
            }
            string[] arr1 = new string[5];
            string[] arr2 = new string[5];
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nenter item number{i + 1} for list one");
                arr1[i] = Console.ReadLine();
            }
            for(int i =0; i < 5; i++)
            {
                Console.WriteLine($"enter item number{i + 1} for list two");
                arr2[i] = Console.ReadLine();
            }
            Shuffle(arr1, arr2);
        }

        public static void Shuffle(string[] arrays1,string[] arrays2)
        {
            Console.Write("[");
            for(int i = 0;i<5;i++)
            {
                Console.Write($"{arrays1[i]}, {arrays2[i]}");
                if(i != 4)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]");
        }

        public static void IsEven(int x)
        {
            if(x % 2 == 0)
            {
                Console.WriteLine($"{x} is even number");
            }
            else 
            {
                Console.WriteLine($"{x} is not an even number");
            }
        }

        public static void MultTable(int x)
        {
            for(int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= x; j++)
                {
                    Console.Write($"{i} x {j} = {i * j}, ");
                }
            }
        }
    }

}
