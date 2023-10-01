using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.IO;
using System.Runtime.CompilerServices;
using System.IO;
using System.ComponentModel.Design;
using System.Security.Principal;

namespace Labb_2_senaste
{
    internal class Display : Bonuses
    {
        static List<Product> products = new List<Product>
        {
        new Product ("Redbull", 20),
        new Product ("Monster Mango Loco", 25),
        new Product ("Marlboro Röd", 50),
        new Product ("Marlboro Light", 50),
        new Product ("LM Röd", 40),
        new Product ("LM Blå", 35),
        new Product ("Solrosfrön", 15),
        new Product ("General White", 45),
        new Product ("Lundgrens Skåne", 40)

        };
        private static List<Bonuses> customers = new List<Bonuses>
        {
        new Bonuses("Knatte", "123", Bonuses.Discounts.Bronze),
        new Bonuses("Fnatte", "321", Bonuses.Discounts.Silver),
        new Bonuses("Tjatte", "231", Bonuses.Discounts.Gold)
        };
        public static customers? loggedInUser;
        
        private static decimal totalPrice = 0;
        private static decimal calculatedDiscountGiven = 0;

        public Display(string Username, string Password, Discounts membershiplevels) : base(Username, Password, membershiplevels)
        {
        }

        /*   public static void InStore()
           {
               products.Add(new Products("LM", 50));
               products.Add(new Products("Redbull", 20));
               products.Add(new Products("Solrosfrön", 20));
               products.Add(new Products("Marlboro", 50));
           }
        */
        /*public static void RegisteredCustomers()
        {
            customers.Add(new Bonuses("Knatte", "123", Bonuses.Discounts.Bronze));
            customers.Add(new Bonuses("Fnatte", "321", Bonuses.Discounts.Silver));
            customers.Add(new Bonuses("Tjatte", "231", Bonuses.Discounts.Gold));
            LoadedCustomers();
        }*/

        private static void LoadedCustomers()
        {
            throw new NotImplementedException();
        }

        public static void DisplayMenu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- WELCOME TO AMO LIVS AND TOBAK -----");
            Console.WriteLine("1. LOG IN");
            Console.WriteLine("2. SIGN UP");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    LogIn();
                    break;
                case "2":
                    SignUp();
                    break;
                default:
                    Console.WriteLine("Invalid option, try again");
                    Console.ReadKey();
                    DisplayMenu();
                    break;
            }



        }
        public static void DisplayMainMenu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"----- WELCOME TO AMO LIVS AND TOBAK -----");
            Console.WriteLine("1. SHOP ");
            Console.WriteLine("2. SHOPPING CART ");
            Console.WriteLine("3. CHECKOUT ");
            Console.WriteLine("4. EXIT ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AmoLivs();
                    break;
                case "2":
                    FinalCart();
                    break;
                case "3":
                    CheckOut();
                    break;
                case "4":
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    Console.ReadKey();
                    DisplayMainMenu();
                    break;
            }
        }

        public static void LogIn()
        {
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            Bonuses? newCustomer = customers.FirstOrDefault(u => u.Username == username);

            if (newCustomer != null)
            {
                if (newCustomer.Password == password)
                {
                    loggedInUser = newCustomer;
                    DisplayMainMenu();
                } else
                {
                    Console.WriteLine("Wrong password, please try again baby");
                    LogIn();

                }


            } else
            {
                Console.WriteLine("The user doesnt exists. Press Y for register a account");
                string userInput = Console.ReadLine();

                if (userInput == "y" || userInput == "Y")
                {
                    SignUp();
                    Console.WriteLine("Please log in.");
                    LogIn();
                }
            }


        }
        public static void SignUp()
        {
            Console.WriteLine("Please choose your username: ");
            string newUsername = Console.ReadLine();

            Console.WriteLine("Please choose your password: ");
            string newPassword = Console.ReadLine();

            if (!string.IsNullOrEmpty(newUsername) && !string.IsNullOrEmpty(newPassword))
            {
                Bonuses newCustomer = new Bonuses(newUsername, newPassword, Bonuses.Discounts.Bronze);
                customers.Add(newCustomer);
            } else
            {
                Console.WriteLine("Must enter a valid username and password");
            }
        }

        public static void AmoLivs()
        {
            Console.Clear();
            
            Console.WriteLine("----- A M O L I V S -----");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.\t{products[i].ProductName},\t{products[i].Price} kronor");
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            }
            Console.WriteLine("Wanna view you cart press 0");

            int pickedProducts;
            

            bool success = int.TryParse(Console.ReadLine(), out pickedProducts);

            if (success && (pickedProducts >= 1) && (pickedProducts <= products.Count))
            {
                Product product = products[pickedProducts - 1];

                
                loggedInUser.ShoppingCart.InStoreProducts.Add(product);
                loggedInUser.ShoppingCart.TotalPrice += product.Price;
                loggedInUser.ShoppingCart.TotalItems++;
                Console.WriteLine($"{product.ProductName} have been added. Press any key to continue shopping.");
                Console.ReadKey();
                AmoLivs();


            }
            else if (success && (pickedProducts == 0))
            {
                loggedInUser.ShoppingCart.Display();
                DisplayMainMenu();
            }
    
            else
            {
                Console.WriteLine("Invalid option, please try again baby");
                Console.ReadKey();
                DisplayMenu();
            }


        }

        public static void FinalCart()
        {
            Console.Clear();

            foreach (Product item in loggedInUser.ShoppingCart.InStoreProducts)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine($"{item.ProductName}, {item.Price}");
            }

            //calculatedDiscountGiven = Math.Round(loggedInUser.discountGiven(totalPrice), 2);
            //Console.WriteLine($"Your cart contains: {loggedInUser.SelectedItems.Sum(c => c.Quantity)} products.");
            Console.WriteLine($"The totalprice is : {loggedInUser.ShoppingCart.TotalPrice} kronor.");
            //Console.WriteLine($"Your total price with the membership discount is : {calculatedDiscountGiven} kronor");

            Console.WriteLine($"Would you like to proceed to the checkout or continue to shop?");
            Console.WriteLine($"1. Checkout");
            Console.WriteLine($"2. Shop");
            string finalChoice = Console.ReadLine();

            switch (finalChoice)
            {
                case "1":
                    CheckOut();
                    break;
                case "2":
                    AmoLivs();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    Console.ReadKey();
                    FinalCart();
                    break;
            }
        }

        public static void CheckOut()
        {
            Console.Clear();
            Bonuses customer = customers.FirstOrDefault(u => u.Username == loggedInUser.Username);
            
            Product.DifferentCurrencies(loggedInUser.ShoppingCart.TotalPrice, customer.DiscountGiven(loggedInUser.ShoppingCart.TotalPrice));

            Console.WriteLine("How would you like to pay?");
            Console.WriteLine("1. Card");
            Console.WriteLine("2. Crypto");
            Console.WriteLine("3. Klarna");
            string paymentOption = Console.ReadLine();

            switch (paymentOption)
            {
                case "1":
                    Console.WriteLine("Enter your card number");
                    Console.ReadLine();
                    Console.WriteLine("Succesful payment");
                    Console.WriteLine("Thank you, please come again");
                    break;

                case "2":
                    Console.WriteLine("Enter your crypto code number");
                    Console.ReadLine();
                    Console.WriteLine("Succesful paymeny");
                    Console.WriteLine("Thank you, please come again");
                    break;

                case "3":
                    Console.WriteLine("Enter your email adress");
                    Console.ReadLine();
                    Console.WriteLine("A invoice has been sent to your email adress");
                    Console.WriteLine("Thank you please come again");
                    break;

                default:
                    Console.WriteLine("Invalid payment, please try again");
                    Console.ReadKey();
                    CheckOut();
                    break;

            }
        }
        public static void LoadCustomers()
        {
            string fileName = "Customers.txt";
            List<string> members = File.ReadAllLines(fileName).ToList();

            foreach (string member in members)
            {
                string[] account = member.Split(',');

                if (account.Length == 3)
                {
                    string Username = account[0];
                    string Password = account[1];
                    string Membershiplevel = account[2];

                    if (Enum.TryParse(Membershiplevel, out Bonuses.Discounts discounts))
                    {
                        Bonuses newBonuses = new Bonuses(Username, Password, Membershiplevel);
                        customers.Add(newBonuses);
                    }
                }
            }
        }



    }
}
