using System;
using System.Collections.Generic;
using System.Linq;

public class Store
{
    public string Name { get; }
    public string Address { get; }
    public List<string> Phones { get; }
    public string Specialization { get; }
    public string WorkingHours { get; }

    public Store(string name, string address, string specialization, string workingHours)
    {
        Name = name;
        Address = address;
        Specialization = specialization;
        WorkingHours = workingHours;
        Phones = new List<string>();
    }

    public void AddPhone(string phone)
    {
        Phones.Add(phone);
    }

    public override string ToString()
    {
        return $"Store(Name='{Name}', Address='{Address}', Phones={string.Join(", ", Phones)}, Specialization='{Specialization}', WorkingHours='{WorkingHours}')";
    }
}

public class StoreDirectory<T>
{
    private List<T> stores = new List<T>();

    public void AddStore(T store)
    {
        stores.Add(store);
    }

    public void DisplayStores()
    {
        foreach (var store in stores)
        {
            Console.WriteLine(store.ToString());
        }
    }

    public void SortByName()
    {
        stores.Sort((store1, store2) => (store1 as Store).Name.CompareTo((store2 as Store).Name));
    }

    public void SortByAddress()
    {
        stores.Sort((store1, store2) => (store1 as Store).Address.CompareTo((store2 as Store).Address));
    }

    public void SortBySpecialization()
    {
        stores.Sort((store1, store2) => (store1 as Store).Specialization.CompareTo((store2 as Store).Specialization));
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var storeDirectory = new StoreDirectory<Store>();

        var store1 = new Store("Store A", "Address A", "Grocery", "Mon-Fri: 9:00-17:00");
        store1.AddPhone("380456785890");
        store1.AddPhone("380654553210");

        var store2 = new Store("Store B", "Address B", "Electronics", "Mon-Fri: 10:00-18:00");
        store2.AddPhone("380111222335");

        var store3 = new Store("Store C", "Address C", "Books", "Mon-Sun: 8:00-20:00");
        store3.AddPhone("380581222335");
        store3.AddPhone("380225645337");

        storeDirectory.AddStore(store1);
        storeDirectory.AddStore(store2);
        storeDirectory.AddStore(store3);

        Console.WriteLine("All Stores:");
        storeDirectory.DisplayStores();

        storeDirectory.SortByName();
        Console.WriteLine("\nStores sorted by name:");
        storeDirectory.DisplayStores();

        storeDirectory.SortByAddress();
        Console.WriteLine("\nStores sorted by address:");
        storeDirectory.DisplayStores();

        storeDirectory.SortBySpecialization();
        Console.WriteLine("\nStores sorted by specialization:");
        storeDirectory.DisplayStores();
    }
}
