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

    static void ZagrajJednaGre(List<string> rysunkiWisielca, List<string> listaHasel)
    {
        throw new NotImplementedException();
    }

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
        return new List<string>{ "fireball", "kopulacja", "Indu", "Staruwka" , "Sauron" , "FC Barcelona"};
    }
        static string WylosujHaslo(List<string> listaHasel)
    {
        Random rng = new Random();
        int liczba = rng.Next(0,listaHasel.Count);
        return listaHasel[liczba];

    }
    static (string zakryteHaslo, int liczbaNieLiter) ZakryjHaslo(string wylosowaneHaslo)
    {
        int liczbaNieLiter = 0;
        char[] hasloDoWyswietlenia = new char[wylosowaneHaslo.Length];

        for(int i = 0; i < wylosowaneHaslo.Length; i++)
        {
            char znak = wylosowaneHaslo[i];

            if (char.IsLetter(znak))
            {
                hasloDoWyswietlenia[i] = '_';
            }
            else
            {
                hasloDoWyswietlenia[i] = znak; 
                liczbaNieLiter++;
            }
        }

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
        char podpowiedz = '?'; 

        int ods = 0;
        for (int i = 0; i < wylosowaneHaslo.Length; i++)
        {
            if (wylosowaneHaslo[i] == podpowiedz && hasloDoWyswietlenia[i] == '_')
            {
               hasloDoWyswietlenia = hasloDoWyswietlenia.Remove(i,1);
               hasloDoWyswietlenia = hasloDoWyswietlenia.Insert(i, podpowiedz.ToString());
               ods++;
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
    int liczbaProb = 0;
    string uzyteLitery = "";

    bool podpowiedzuzyta = false;

        while (liczbaOdslonietychLiter < wylosowaneHaslo.Length - liczbaNieLiter)
        {
            Console.Clear();
            Console.WriteLine(hasloDoWyswietlenia);
            Console.WriteLine($"Użyte litery: {uzyteLitery}");
            if(podpowiedzuzyta == true)
                Console.WriteLine("Aby dostać podpowiedź napisz ? ");

            Console.Write("Podaj literę: ");

            string wejscie = Console.ReadLine() ?? "";
            if(wejscie.Length == 0)
                continue;
            
            if(wejscie[0] == '?')
            {
                if (podpowiedzuzyta)
                {
                    Console.WriteLine("Nie oszukuj już zużyłeś");
                    Thread.Sleep(1200);
                    continue;
                }
                int ods;
                (hasloDoWyswietlenia,ods) = UzyjPodpowiedzi(wylosowaneHaslo,hasloDoWyswietlenia, uzyteLitery);
                liczbaOdslonietychLiter += ods;
                podpowiedzuzyta = true;
                liczbaProb++;
                continue;
            }

                



            
        }
    }
}