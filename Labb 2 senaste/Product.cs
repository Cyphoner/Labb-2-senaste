using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_senaste
{
    internal class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Product(string productname, decimal price)
        {
            ProductName = productname;
            Price = price;
        }

        public static void DifferentCurrencies(decimal price, decimal newPrice)
        {
            decimal euro = price / 11.54m;
            decimal dollar = price / 10.92m;

            Console.WriteLine("Choose your currency you would like to pay with:");
            Console.WriteLine($"1. SEK {price}");
            Console.WriteLine($"2. Euro {Math.Round(euro, 2)}");
            Console.WriteLine($"3. Dollar {Math.Round(dollar, 2)}");

            Console.WriteLine("With discounts");
            euro = newPrice / 11.54m;
            dollar = newPrice / 10.92m;

            Console.WriteLine($"1. SEK {newPrice}");

            Console.WriteLine($"2. Euro {Math.Round(euro, 2)}");

            Console.WriteLine($"3. Dollar {Math.Round(dollar, 2)}");
            string ChosenCurrency = Console.ReadLine();

            switch(ChosenCurrency)
            {
                case "1":
                    Console.WriteLine($"Your total price is: {newPrice} kronor.");
                    break;
                case "2":
                    Console.WriteLine($"Your total price is: {Math.Round(euro, 2)} euros.");
                    break;
                case "3":
                    Console.WriteLine($"Your total price is: {Math.Round(dollar, 2)} dollars.");
                    break;

            }
        }
    }
}
