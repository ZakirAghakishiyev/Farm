using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm;

internal class DataContext
{
    public DataContext(Farmer[] farmers, Customer[] customer, Farm[] farms, User[] users, Animal[] animals)
    {
        Farmers = farmers;
        Customers = customer;
        Farms = farms;
        Users = users;
        Animals = animals;
    }

    public DataContext()
    {
        Animals = new Animal[10];
        Animals[0] = new Animal("Inek", 1000);
        Animals[1] = new Animal("Qoyun", 250);
        Animals[2] = new Animal("Quzu", 200);
        Animals[3] = new Animal("Toyuq", 15);

        Farms = new Farm[10];
        Farms[0] = new Farm("Beyleqan", [Animals[1], Animals[2]]);
        Farms[1] = new Farm("Baki", [Animals[0], Animals[1],Animals[3]]);
        Farmers = new Farmer[10];

        Farmers[0] = new Farmer(Farms[0],"Feqan");
        Farmers[1] = new Farmer(Farms[1],"Ziyad");

        Customers = new Customer[10];
        Customers[0] = new Customer("Abbas",1500);
        Customers[1] = new Customer("Elovset",150);

        Users = new User[20];
        Users[0] = new User("fermer", "1234", Farmers[1].Id,"farmer");
        Users[1] = new User("musteri", "1234", Customers[1].Id,"customer");

        Items = new Item[20];

        Basket=new Basket();

    }

    public Farmer[] Farmers { set; get; }
    public Customer[] Customers { set; get; }
    public Farm[] Farms { set; get; }
    public User[] Users { set; get; }
    public Animal[] Animals { set; get; }
    public Item[] Items { set; get; }
    public Basket Basket { set; get; }

    public void AddAnimal(string name, decimal price)
    {
        Console.Write("Name of the animal");
        name = Console.ReadLine();
        Console.Write("Price of the animal");
        price = decimal.Parse(Console.ReadLine());
        Animal animal = new Animal(name, price);
        for (int i = 0; i < Animals.Length; i++)
        {
            {
                if (Animals[i] == null) Animals[i] = animal;
            }
            break;
        }
        foreach (var item in Animals)
        {
            if (item == null) continue;
            Console.WriteLine(item.Name, item.Price, item.Id);
        }
    }
    public bool isAuthenticUser(string username,string password, out int id)
    {
        foreach (var item in Users)
        {
            if (item == null) continue;
            if (username == item.UserName && password == item.Password) { 
                id= item.Id;
                return true; 
            }
        }
        id = -1;
        return false;
    }

    public User GetUserById(int id)
    {
        foreach (var item in Users)
        {
            if (item == null) continue;
            if (item.Id == id) return item;
        }

        return null;
    }

    public Farmer GetFarmerById(int id)
    {
        foreach(var item in Farmers)
        {
            if (item == null) continue;
            if (item.Id == id) return item;
        }

        return null;
    }
    public Customer GetCustomerById(int id)
    {
        foreach (var item in Customers)
        {
            if (item == null) continue;
            if (item.Id == id) return item;
        }

        return null;
    }

    public Animal GetAnimalById(int id)
    {
        foreach (var item in Animals)
        {
            if (item == null) continue;
            if (item.Id == id) return item;
        }

        return null;
    }

    public Farm GetFarmById(int id)
    {
        foreach (var item in Farms)
        {
            if (item == null) continue;
            if (item.Id == id) return item;
        }

        return null;
    }

    public void AddAnimal()
    {
        Console.Write("Name: ");
        string name=Console.ReadLine();
        Console.Write("Price: ");
        decimal price=decimal.Parse(Console.ReadLine());

        Animal animal = new Animal(name, price);

        for (int i = 0; i < Animals.Length; i++)
        {
            if (Animals[i] == null)
            {
                Animals[i] = animal;
                return;
            }
        }
    }


    public void AddAnimalToFarm()
    {
        PrintAnimals(Animals);
        Console.Write("Insert ID of the animal you want: ");
        int animalId=int.Parse(Console.ReadLine());
        PrintFarms(Farms);
        Console.Write("Choose ID of the farm you want to add: ");
        int farmId=int.Parse(Console.ReadLine());

        var animal=GetAnimalById(animalId);
        //Console.WriteLine(animal.Name);
        var farm=GetFarmById(farmId);
        //Console.WriteLine(farm.Name);
        Animal[] animals = new Animal[farm.Animals.Length + 1];
        animals = [.. farm.Animals, animal];
        farm.Animals = animals;
        PrintAnimals(farm.Animals);

    }

    public void ModifyAnimal()
    {
        PrintAnimals(Animals);
        Console.Write("Insert ID of the animal you want: ");
        int animalId = int.Parse(Console.ReadLine());
        Console.WriteLine("Inser new price:");
        decimal price=decimal.Parse(Console.ReadLine());
        var animal=GetAnimalById(animalId);
        animal.Price = price;
        PrintAnimals(Animals);
    }

    public void RemoveAnimal()
    {
        PrintFarms(Farms);
        Console.Write("Choose ID of the farm you want to add: ");
        int farmId = int.Parse(Console.ReadLine());
        var farm=GetFarmById(farmId);
        PrintAnimals(farm.Animals);
        Console.Write("Insert ID of the animal you want to remove: ");
        int animalId = int.Parse(Console.ReadLine());
        for (int i = 0; i < farm.Animals.Length; i++)
        {
            if (farm.Animals[i].Id == animalId)
            {
                farm.Animals[i] = null;
                PrintAnimals(farm.Animals);
                return;
            }
        }
    }
    
    public void AddItemToBasket()
    {
        PrintFarms(Farms);
        Console.WriteLine("Choose Farm you want to shop from.");
        Console.Write("ID: ");
        int farmId=int.Parse(Console.ReadLine());
        PrintAnimals(GetFarmById(farmId).Animals);
        Console.WriteLine("Choose Item you want to add to basket.");
        Console.Write("ID: ");
        int animalId = int.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        decimal quantity=decimal.Parse(Console.ReadLine());
        var animal=GetAnimalById(animalId);
        var item=new Item(animal,quantity,quantity*animal.Price);
        for(int i = 0;i<Items.Length;i++)
        {
            if (Items[i] == null)
            {
                Items[i] = item;
                break;
            }
        }
        decimal total = 0;
        foreach(var singleItem in Items)
        {
            if (singleItem != null)
            {
                total += singleItem.Total;
            }
        }
        Basket=new Basket(Items,total);
        PrintBasket();
    }

    public void PrintBasket()
    {
        for(int i=0;i<Items.Length;i++)
        {
            if(Items[i] != null)
            {
                Console.WriteLine(new string('-',30));
                Console.WriteLine($"Item {i+1}:");
                Console.WriteLine($"Name: {Items[i].ItemInBasket.Name}");
                Console.WriteLine($"Quantity: {Items[i].Quantity}");
                Console.WriteLine($"Price: {Items[i].Total}");
                Console.WriteLine(new string('-',30));
            }
        }
        Console.WriteLine($"Total: {Basket.Total}");
    }
    public void PrintFarms(Farm[] farms)
    {
        foreach(var farm in farms)
        {
            if(farm == null) continue;

            Console.WriteLine(new string('-',25));
            Console.WriteLine($"ID:{ farm.Id}");
            Console.WriteLine($"Name:{ farm.Name}");
            Console.WriteLine("Animals of the farm:");
            foreach (var item in farm.Animals)
            {
                Console.WriteLine($"{item.Id,-3} {item.Name,-20}");
            }
            Console.WriteLine(new string('-',25));
        }
    }

    public void RemoveFromBasket()
    {
        PrintBasket();
        Console.WriteLine("ID of the item you want to remove: ");
        int id=int.Parse(Console.ReadLine());
        for(int i=0;i< Items.Length; i++)
        {
            if (Items[i].ItemInBasket.Id == id)
            {
                Basket.Total -= Items[i].Total;
                Items[i] = null;
                break;
            }
        }
        
        PrintBasket();
    }

    public void Order(Customer customer) 
    {
        if(!(customer.Budget<Basket.Total))
        {
            customer.Budget -= Basket.Total;
            Console.WriteLine("Order is completed sucsessfully! :)");
            Console.WriteLine($"You have {customer.Budget} left");
            Items = new Item[20];
            Basket = new Basket();
        }
        else Console.WriteLine("Insufficient Balance!!!");
    }

    public void PrintAnimals(Animal[] animals)
    {
        Console.WriteLine(new string('-',25));
        Console.WriteLine($"{"ID",-3}|{"Name",-15}|{"Price",-7}");
        foreach(Animal item in animals)
        {
            if(item==null) continue;
            Console.WriteLine($"{item.Id,-3}|{item.Name,-15}|{item.Price,-7}");

        }
        Console.WriteLine(new string('-',25));
    }
}
