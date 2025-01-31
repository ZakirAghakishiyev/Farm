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
        Farmers = new Farmer[10];
        Farmers[0] = new Farmer(Farms[0],"Feqan","Farmer");
        Farmers[1] = new Farmer(Farms[1],"Ziyad","Farmer");

        Customers = new Customer[10];
        Customers[0] = new Customer("Abbas","Customer",1500);
        Customers[1] = new Customer("Elovset","Customer",150);

        Farms = new Farm[10];
        Farms[0] = new Farm("Beyleqan", [Animals[1], Animals[2]], [Farmers[0]]);
        Farms[0] = new Farm("Baki", [Animals[0], Animals[1],Animals[3]], [Farmers[1]]);
        

        Users = new User[20];
        Users[0] = new User("fermer", "1234", Farmers[1].Id);
        Users[0] = new User("musteri", "1234", Customers[1].Id);

        Animals = new Animal[10];
        Animals[0] = new Animal("Inek", 1000);
        Animals[1] = new Animal("Qoyun", 250);
        Animals[2] = new Animal("Quzu", 200);
        Animals[3] = new Animal("Toyuq", 15);


    }

    public Farmer[] Farmers { set; get; }
    public Customer[] Customers { set; get; }
    public Farm[] Farms { set; get; }
    public User[] Users { set; get; }
    public Animal[] Animals { set; get; }

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
}
