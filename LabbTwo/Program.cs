using System.Numerics;
using System.Threading.Channels;

namespace LabbTwo
{
    internal class Program
    {
        static List<Customer> customerList = new List<Customer>();
        static Customer loggedInCustomer = null;
        static void Main(string[] args)
        {
            Customer customer1 = new Customer("Knatte", "123");
            Customer customer2 = new Customer("Fnatte", "321");
            Customer customer3 = new Customer("Tjatte", "213");


            customerList.Add(customer1);
            customerList.Add(customer2);
            customerList.Add(customer3);

            Store shop = new Store();
            shop.Name = "Burgeria";
            Console.WriteLine("-----------");
            Console.WriteLine($"Welcome to {shop.Name}!");
            Console.WriteLine("-----------");

            while (true)
            {
                Console.WriteLine("Please select one of the following options: ");
                Console.WriteLine("1: Log in");
                Console.WriteLine("2: Register new account");
                Console.WriteLine("3: Quit");
                Console.WriteLine("Please enter your choice: ");
                Console.WriteLine("-------------");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LogIn();
                        break;
                    case "2":
                        RegisterCustomer(customerList);
                        break;
                    case "3":
                        Console.WriteLine("Have a nice day!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Oops, something went wrong, please try again. ");
                        break;


                }
            }
            static void LogIn()
            {
                Console.WriteLine("Please enter your username: ");
                Console.WriteLine("-------------");
                string userName = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                Console.WriteLine("-------------");
                string password = Console.ReadLine();

                loggedInCustomer = customerList.Find(customer => customer.Name == userName && customer.VerifyPassword(password));
                if (loggedInCustomer != null)
                {
                    Console.WriteLine($"Welcome, {loggedInCustomer.Name}!");
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("The account does not exist or the username/passsword is wrong.");
                    Console.WriteLine("Would you like to register a new? (yes/no)");
                    Console.WriteLine("-------------");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "yes")
                    {
                        RegisterCustomer(customerList);
                    }
                }
            }

            static void RegisterCustomer(List<Customer> customers)
            {
                Console.WriteLine("Please enter your username: ");
                Console.WriteLine("-------------");
                string userName = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                Console.WriteLine("-------------");
                string password = Console.ReadLine();

                if (customers.Exists(customer => customer.Name == userName))
                {
                    Console.WriteLine("The account already exists.");
                    Console.WriteLine("-------------");
                }
                else
                {
                    customers.Add(new Customer(userName, password));
                    Console.WriteLine("The account has been registered.");
                    Console.WriteLine("-------------");
                }
            }
        }
        static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nThis is the main menu:");
                Console.WriteLine("1: Shop");
                Console.WriteLine("2: View my cart");
                Console.WriteLine("3: Proceed to checkout");
                Console.WriteLine("4: Logout");
                Console.WriteLine("Please select one of the following options: ");
                Console.WriteLine("-------------");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Shop();
                        break;
                    case "2":
                        ViewCart();
                        break;
                    case "3":
                        ProcedeToCheckout();
                        break;
                    case "4":
                        loggedInCustomer = null;
                        Console.WriteLine("You have logged out!");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void Shop()
        {
            Console.WriteLine("What would you like to order?: ");
            Product[] products = {
                new Product("Burger", 80),
                new Product("Soda", 15),
                new Product("Hotdog", 20),
                new Product("Fries", 23),

            };
            Console.WriteLine("------------");



            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {products[i].Name} - {products[i].Price} SEK");
            }

            Console.WriteLine("Please input a number that represents the food/drink you want. ");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= products.Length)
            {
                Console.WriteLine("How many would you like?");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    loggedInCustomer.AddToCart(products[choice - 1], quantity);
                    Console.WriteLine($"{quantity} {products[choice - 1].Name} has been added to the cart. ");
                }
                else
                {
                    Console.WriteLine("Invalid quantity, please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
                    
        
            


            
            static void ViewCart()
            {
                Console.WriteLine("This is your cart: ");
                Console.WriteLine(loggedInCustomer.Cart);
                Console.WriteLine($"Total cost is: {loggedInCustomer.Cart.CalculateTotalCost()} SEK");
            }

            static void ProcedeToCheckout()
            {
                Console.WriteLine("Your checkout");
                Console.WriteLine(loggedInCustomer);
                double totalCost = loggedInCustomer.Cart.CalculateTotalCost();
                Console.WriteLine($"The total cost is: {totalCost} SEK");
                Console.WriteLine("Thank you for the purchase, goodbye!");
                loggedInCustomer.EmptyCart();
            }
        }
    }

