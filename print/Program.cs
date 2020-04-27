using System;

namespace print
{
    class Program
    {
        static void Main(string[] args)
        {
            int sweetNSalty =0;//record of how many times the sweetNSalty accord
            int sweet =0;//record of how many times the sweet accord
            int salty =0;//record of how many times the salty accord
            for(int i =1;i<=100;i++)// loop from 1 to 100
            {
                if(i % 3 == 0 && i % 5 == 0)//check if the numbers divided by 3 and 5
                {
                    Console.WriteLine("sweet’nSalty");//print the sweet’nSalty
                    sweetNSalty++;//increase the sweetNSalty by one
                }
                else if(i % 3 == 0)//check if the number divided by 3
                {
                    Console.WriteLine("sweet");//print the sweet
                    sweet++;//increase the sweet by one
                }else if(i % 5 == 0)//check if the number divided by 5
                {
                    Console.WriteLine("salty");//print the salty
                    salty++;//increase the salty by one
                }else//if the number is not divided by 3 or 5
                {
                    Console.WriteLine($"{i}");//print the number
                }
            }
            Console.WriteLine($"there was {sweet} sweet, {salty} salty and {sweetNSalty} sweetNSalty in this round");//print the number of how many time the salty, sweet and sweetNSalty accord
        }
    }
}
