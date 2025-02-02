namespace Farm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataContext=new DataContext();
            string username;
            string password;
            int id;
            bool flag=false;
            do
            {
                if (flag)
                {
                    Console.WriteLine("Password or Username is incorrect");
                }
                flag = true;
                Console.Write("Username: ");
                username=Console.ReadLine();
                Console.Write("Password: ");
                password=Console.ReadLine();
            } while (!dataContext.isAuthenticUser(username,password,out id));
            var user = dataContext.GetUserById(id);
            bool welcome = true;
            while (true)
            {
                if (user.UserType == "farmer")
                {
                    var farmer = dataContext.GetFarmerById(id);
                    if(welcome) Console.WriteLine($"Welcome {farmer.Name}");
                    welcome = false;
                    Console.WriteLine("Choose action you want to take:");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Add a new animal");
                    Console.WriteLine("2. Add an animal to a farm");
                    Console.WriteLine("3. Change price");
                    Console.WriteLine("4. Remove an animal from a farm");

                    int input = int.Parse(Console.ReadLine());
                    if (input == 0) return;
                    else if (input == 1)
                    {
                        dataContext.AddAnimal();
                        dataContext.PrintAnimals(dataContext.Animals);
                    }
                    else if (input == 2)
                    {
                        dataContext.AddAnimalToFarm();
                    }
                    else if(input == 3)
                    {
                        dataContext.ModifyAnimal();
                    }
                    else if (input == 4)
                    {
                        dataContext.RemoveAnimal();
                    }
                    else Console.WriteLine("Invalid input");
                }

                else if (user.UserType == "customer")
                {
                    var customer = dataContext.GetCustomerById(id);
                    if(welcome) Console.WriteLine($"Welcome {customer.Name}");
                    welcome = false;
                    while (true)
                    {
                        Console.WriteLine("0. Exit");
                        Console.WriteLine("1. Add to basket");
                        Console.WriteLine("2. Remove from basket");
                        Console.WriteLine("3. Show basket");
                        Console.WriteLine("4. Order");
                        int input = int.Parse(Console.ReadLine());
                        if(input == 0) return;
                        else if (input == 1)
                        {
                            dataContext.AddItemToBasket();
                        }
                        else if (input == 2)
                        {
                            dataContext.RemoveFromBasket();
                        }
                        else if (input == 3)
                        {
                            dataContext.PrintBasket();
                        }
                        else if (input == 4)
                        {
                            dataContext.Order(customer);
                        }
                        else Console.WriteLine("Invalid input");
                    }
                }
            }

        }
    }
}
