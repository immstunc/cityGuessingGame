using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuessingGame
{
    internal class Program
    {
        static string[] cities;
        static int scoree = 0, errorCount = 10;
        static int cityCount = 0;

        static void Main(string[] args)
        {
            game();

        }
        public static void game()
        {

            Console.WriteLine("--------------------------");
            Console.WriteLine("----City Guessing Game----");
            Console.WriteLine("--------------------------");
            enterCity();
            bool status = true;
            while (status)
            {

                Console.WriteLine("--------------------------");
                Console.WriteLine("---------City List--------");
                Console.WriteLine("--------------------------");

                getCities();

                Console.WriteLine("--------------------------");
                Console.WriteLine("What's Your City Estimate?");
                Console.WriteLine("--------------------------");
                Random random = new Random();
                int randomNumber = random.Next(0, cityCount);
                string systemSelectCity = cities[randomNumber];

                Console.Write("City: ");
                string myCity = Console.ReadLine();

                cityControl(myCity, systemSelectCity);

                status = userWinOrLose();

                Console.ReadKey();
                Console.Clear();
            }

        }
        public static void enterCity()
        {
            Console.Write("Enter City Count: ");
            cityCount = Convert.ToInt32(Console.ReadLine());

            cities = new string[cityCount];

            for (int i = 0; i < cityCount; i++)
            {
                Console.Write((i + 1) + ". City: ");
                cities[i] = Console.ReadLine();
            }
        }
        public static void getCities()
        {
            for (int i = 0; i < cityCount; i++)
            {
                Console.WriteLine((i + 1) + " - " + cities[i]);
            }
        }
        public static bool userWinOrLose()
        {
            if (scoree == 5)
            {
                Console.WriteLine("\n--------------------------");
                Console.WriteLine("----------You Win---------");
                Console.WriteLine("--------------------------");
                return false;
                Console.ReadKey();
            }
            else if (errorCount == 0)
            {
                Console.WriteLine("\n--------------------------");
                Console.WriteLine("----------You Lose--------");
                Console.WriteLine("--------------------------");
                return false;
                Console.ReadKey();
            }
            return true;
        }
        public static void cityControl(string myCity, string systemSelectCity)
        {
            if (myCity.ToLower() == systemSelectCity.ToLower())
            {
                Console.WriteLine("Congratulations Correct Guess.");
                scoree++;
            }
            else
            {
                Console.WriteLine("Sorry Wrong Guess!");
                errorCount--;
            }

            Console.WriteLine("The Value You Entered   : " + myCity);
            Console.WriteLine("The Value System Entered: " + systemSelectCity);
            Console.WriteLine("Scoree     : " + scoree);
            Console.WriteLine("Errors Left: " + errorCount);
        }
    }
}