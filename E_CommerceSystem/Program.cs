namespace E_CommerceSystem
{
    internal class Program
    {
        static ECommerceContext context = new ECommerceContext();
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("================================================");
                Console.WriteLine("        E-COMMERCE SYSTEM");
                Console.WriteLine("================================================");
                Console.WriteLine(" 1.Register a New User");
                Console.WriteLine(" 2.Add a New Product");
                Console.WriteLine(" 3.Place an Order");
                Console.WriteLine(" 4.Write a Product Review");
                Console.WriteLine(" 5.Update Product Price & Availability");
                Console.WriteLine(" 6.Cancel an Order");
                Console.WriteLine(" 7.Delete a Review");
                Console.WriteLine(" 8.View All Products");
                Console.WriteLine(" 9.Filter Products by Category & Price Range");
                Console.WriteLine("10.Get Category with All Its Products");
                Console.WriteLine("11.View Order History with Full Details");
                Console.WriteLine("12.Product Summary Report");
                Console.WriteLine(" 0.Exit");
                Console.WriteLine("================================================");
                Console.Write("Enter your choice: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            RegisterUser();
                            break;

                        case "2":
                            break;

                        case "3":
                            break;

                        case "4":
                            break;

                        case "5":
                            break;

                        case "6":
                            break;

                        case "7":
                            break;

                        case "8":
                            break;

                        case "9":
                            break;

                        case "10":
                            break;

                        case "11":
                            break;

                        case "12":
                            break;

                        case "0": running = false; Console.WriteLine("Goodbye!");
                            break;

                        default: Console.WriteLine("Invalid choice! Try again.");
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                static void RegisterUser()
                {

                }
            }
        }
    }
}
    

