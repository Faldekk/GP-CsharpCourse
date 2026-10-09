using System;
using System.Collections.Generic;
namespace StrukturyDanych;
class Program
{
    static void Main()
    {
        int maxWeight = 25;

        Dictionary<string, int> items = new Dictionary<string, int>()
        {
            {"Mikstura", 1},
            {"Antidotum", 1}
        };

        List<string> inventory = new List<string>();

        bool running = true;
        while (running)
        {
            Console.Clear();
            PrintInventory(inventory, items, maxWeight);
            PrintOptions();
            
            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                Console.Clear();
                PrintShop(items);
                Console.WriteLine("\nNaciśnij dowolny klawisz...");
                Console.ReadKey(true);
            }
            else if (choice == "2")
            {
                Console.Clear();
                PrintShop(items);

                Console.Write("\nWpisz nazwę przedmiotu do dodania: ");
                string name = (Console.ReadLine() ?? "").Trim();

                if (!items.ContainsKey(name))
                {
                    Console.WriteLine("❌ Nie ma takiego przedmiotu w ofercie.");
                    Pause();
                    continue;
                }

                int currentWeight = GetTotalWeight(inventory, items);
                int itemWeight = items[name];

                if (currentWeight + itemWeight > maxWeight)
                {
                    Console.WriteLine($"❌ Za ciężkie! Brakuje miejsca na wagę {itemWeight}.");
                    Pause();
                    continue;
                }

                inventory.Add(name);
                Console.WriteLine($"✅ Dodano: {name}");
                Pause();
            }
            else if (choice == "3")
            {
                Console.Clear();
                PrintInventory(inventory, items, maxWeight);

                Console.Write("\nWpisz nazwę przedmiotu do usunięcia: ");
                string name = (Console.ReadLine() ?? "").Trim();

                if (!inventory.Contains(name))
                {
                    Console.WriteLine("❌ Nie masz takiego przedmiotu w plecaku.");
                    Pause();
                    continue;
                }

                inventory.Remove(name);
                Console.WriteLine($"✅ Usunięto: {name}");
                Pause();
            }
            else if (choice == "4")
            {
                inventory.Clear();
                Console.WriteLine("🧹 Ekwipunek wyczyszczony.");
                Pause();
            }
            else if (choice == "5")
            {
                Console.WriteLine("🏰 Wyruszasz do lochu!");
                Pause();
                running = false;
            }
            else
            {
                Console.WriteLine("❌ Nieprawidłowy wybór.");
                Pause();
            }
        }
    }

    static int GetTotalWeight(List<string> inventory, Dictionary<string, int> items)
    {
        int total = 0;
        foreach (string name in inventory)
        {
            if (items.ContainsKey(name))
                total += items[name];
        }
        return total;
    }

    static void PrintShop(Dictionary<string, int> items)
    {
        Console.WriteLine("=== SKLEP / PRZEDMIOTY ===");
        // Wyświetl listę produktów w sklepie
    }

    static void PrintInventory(List<string> inventory, Dictionary<string, int> items, int maxWeight)
    {
        Console.WriteLine("=== EKWIPUNEK ===");
        if (inventory.Count == 0)
        {
            Console.WriteLine("(pusty)");
        }
        else
        {
            // Wyświetl listę przedmiotów w ekwipunku
        }

        int total = GetTotalWeight(inventory, items);
        Console.WriteLine($"Waga: {total}/{maxWeight}");
    }

    static void Pause()
    {
        Console.WriteLine("\nNaciśnij dowolny klawisz...");
        Console.ReadKey(true);
    }
    
    static void PrintOptions()
    {
        Console.WriteLine("\n=== MENU ===");
        Console.WriteLine("1) Pokaż ofertę");
        Console.WriteLine("2) Dodaj przedmiot");
        Console.WriteLine("3) Usuń przedmiot");
        Console.WriteLine("4) Wyczyść ekwipunek");
        Console.WriteLine("5) Wyjście do lochu");
        Console.Write("Wybór: ");
    }
}

