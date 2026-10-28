namespace Klasy;

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie obiektu
        Film wp = new Film("Władca Pierścieni", "Fantasy", 2001);
        Book fn = new Book("Fortnite songs", "Kanye West", 2026);

        Gracz gracz1 = new Gracz(100, "Baltazar");
        Gracz gracz2 = new Gracz(100, "Romek");

        Console.WriteLine($"{wp.Tytul} {wp.Gatunek} {wp.Rok}");
        Console.WriteLine($"{fn.Tytul} {fn.Autor} {fn.Rok}");

        wp.watched(); 
        fn.readtosleep();

        gracz1.zaatak();
        gracz2.zaatak();
        gracz2.zaatak();
        Console.WriteLine($"Gracz 1 hp {gracz1.hp} vs Gracz 2 hp {gracz2.hp}");
    }
}
