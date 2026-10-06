using System;
using System.Collections.Generic;
using System.Threading;

class Gra
{
    static void Main()
    {
        List<string> rysunkiWisielca = UtworzRysunkiWisielca(); 
        List<string> listaHasel = UtworzListeHasel();           

        while (true) 
        {
            ZagrajJednaGre(rysunkiWisielca, listaHasel);

            if (!CzyZagracPonownie())
                break;
        }
    }

    // Uruchamia jedną pełną rozgrywkę
    static void ZagrajJednaGre(List<string> rysunkiWisielca, List<string> listaHasel)
    {
        throw new NotImplementedException();
    }

    // Metoda tworząca rysunki wisielca na różnych etapach gry (LISTA)
    static List<string> UtworzRysunkiWisielca()
    {
        return new List<string>
        {
            "",
            @"
    +---+
    |   |
        |
        |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
        |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
    |   |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
   /|   |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
   /|\  |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
   /|\  |
   /    |
        |
=========",
            @"
    +---+
    |   |
    O   |
   /|\  |
   / \  |
        |
========="
        };
    }

    // Metoda tworząca listę haseł (LISTA)
    static List<string> UtworzListeHasel()
    {
        return new List<string>
        {
            // Wymyśl hasła
        };
    }
        static string WylosujHaslo(List<string> listaHasel)
    {
       throw new NotImplementedException();
    }
    static (string zakryteHaslo, int liczbaNieLiter) ZakryjHaslo(string wylosowaneHaslo)
    {
        int liczbaNieLiter = 0;
        char[] hasloDoWyswietlenia = new char[wylosowaneHaslo.Length];

        // Petla do sprawdzania znaków (Użyj komendy Isletter())

        string zakryteHaslo = new string(hasloDoWyswietlenia);
        return (zakryteHaslo, liczbaNieLiter);
    }

    
    static (string noweHasloDoWyswietlenia, int ileOdsłonieto) UzyjPodpowiedzi(
        string wylosowaneHaslo,
        string hasloDoWyswietlenia,
        string uzyteLitery)
    {
        List<char> ukryteLitery = new List<char>();

        for (int i = 0; i < wylosowaneHaslo.Length; i++)
        {
            if (char.IsLetter(wylosowaneHaslo[i]) && hasloDoWyswietlenia[i] == '_')
            {
                char lit = wylosowaneHaslo[i];
                if (!ukryteLitery.Contains(lit) && !uzyteLitery.Contains(lit))
                    ukryteLitery.Add(lit);
            }
        }

        if (ukryteLitery.Count == 0)
            return (hasloDoWyswietlenia, 0);

        Random rng = new Random();
        char podpowiedz = 'c'; 

        int ods = 0;
        for (int i = 0; i < wylosowaneHaslo.Length; i++)
        {
            if (wylosowaneHaslo[i] == podpowiedz && hasloDoWyswietlenia[i] == '_')
            {
               // logika podmiany znaku
            }
        }

        Console.WriteLine($"Podpowiedź: odsłonięto literę '{podpowiedz}'.");
        Thread.Sleep(1200);

        return (hasloDoWyswietlenia, ods);
    }

  
    static bool CzyZagracPonownie()
    {
        Console.Write("\nCzy chcesz zagrać ponownie? (t/n): ");
        string odp = (Console.ReadLine() ?? "").Trim().ToLower();
        throw new NotImplementedException(); // napisz poprawny return 
    }

    
    static void PokazPodsumowanie(bool wygrana, string haslo, int proby, int pomylki, int odsloniete, int liczbaNieLiter)
    {
        int literyDoOdgadniecia = haslo.Length - liczbaNieLiter;

        Console.WriteLine("\n=== PODSUMOWANIE ROZGRYWKI ===");
        Console.WriteLine("Wynik: " + (wygrana ? "WYGRANA" : "PRZEGRANA"));
        Console.WriteLine($"Hasło: {haslo}");
        Console.WriteLine($"Liczba prób: {proby}");
        Console.WriteLine($"Liczba pomyłek: {pomylki}");
        Console.WriteLine($"Odsłonięte litery: {odsloniete} / {literyDoOdgadniecia}");
        Console.WriteLine("==============================");
    }



    static void OdgadujHaslo(
    string wylosowaneHaslo,
    string hasloDoWyswietlenia,
    int liczbaNieLiter,
    List<string> rysunkiWisielca)
    {
    int liczbaPomylek = 0;
    int liczbaOdslonietychLiter = 0;
    string uzyteLitery = "";
    // To piszemy razem :)

    throw new NotImplementedException();
    }
}