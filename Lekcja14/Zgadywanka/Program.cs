using System;
using System.Collections.Generic;
using System.Threading;

class HelloWorld
{
    static void Main()
    {
        List<string> rysunkiWisielca = UtworzRysunkiWisielca(); // LISTA
        List<string> listaHasel = UtworzListeHasel();           // LISTA

        while (true) // ponowna gra
        {
            ZagrajJednaGre(rysunkiWisielca, listaHasel);

            if (!CzyZagracPonownie())
                break;
        }
    }

    // Uruchamia jedną pełną rozgrywkę
    static void ZagrajJednaGre(List<string> rysunkiWisielca, List<string> listaHasel)
    {
        string wylosowaneHaslo = WylosujHaslo(listaHasel);
        (string hasloDoWyswietlenia, int liczbaNieLiter) = ZakryjHaslo(wylosowaneHaslo);

        (bool wygrana, int proby, int pomylki, int odsloniete) =
            OdgadujHaslo(wylosowaneHaslo, hasloDoWyswietlenia, liczbaNieLiter, rysunkiWisielca);

        PokazPodsumowanie(wygrana, wylosowaneHaslo, proby, pomylki, odsloniete, liczbaNieLiter);
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
            "programista",
            "obóz",
            "środowisko",
            "język programowania",
            "gigant"
        };
    }

    // Metoda losująca jedno hasło z listy haseł (LISTA)
    static string WylosujHaslo(List<string> listaHasel)
    {
        Random maszynaLosujaca = new Random();
        int wylosowanyNumerHasla = maszynaLosujaca.Next(0, listaHasel.Count);
        return listaHasel[wylosowanyNumerHasla];
    }

    // Metoda zakrywająca litery w haśle za pomocą znaków '_' oraz licząca znaki, które nie są literami
    static (string zakryteHaslo, int liczbaNieLiter) ZakryjHaslo(string wylosowaneHaslo)
    {
        int liczbaNieLiter = 0;
        char[] hasloDoWyswietlenia = new char[wylosowaneHaslo.Length];

        for (int i = 0; i < wylosowaneHaslo.Length; i++)
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

    // NOWA METODA #1: Mechanika jednorazowej podpowiedzi (losowa litera)
    // Zwraca: zaktualizowane hasło do wyświetlenia + ile liter odsłonięto dzięki podpowiedzi
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
        char podpowiedz = ukryteLitery[rng.Next(0, ukryteLitery.Count)];

        int ods = 0;
        for (int i = 0; i < wylosowaneHaslo.Length; i++)
        {
            if (wylosowaneHaslo[i] == podpowiedz && hasloDoWyswietlenia[i] == '_')
            {
                hasloDoWyswietlenia = hasloDoWyswietlenia.Remove(i, 1);
                hasloDoWyswietlenia = hasloDoWyswietlenia.Insert(i, podpowiedz.ToString());
                ods++;
            }
        }

        Console.WriteLine($"Podpowiedź: odsłonięto literę '{podpowiedz}'.");
        Thread.Sleep(1200);

        return (hasloDoWyswietlenia, ods);
    }

    // NOWA METODA #2: Pytanie o ponowną grę
    static bool CzyZagracPonownie()
    {
        Console.Write("\nCzy chcesz zagrać ponownie? (t/n): ");
        string odp = (Console.ReadLine() ?? "").Trim().ToLower();
        return odp == "t" || odp == "tak";
    }

    // NOWA METODA #3: Podsumowanie gry
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

    // Metoda realizująca główną logikę gry (LISTA: rysunki)
    // Zwraca statystyki: (czyWygrana, liczbaProb, liczbaPomylek, liczbaOdsłoniętychLiter)
    static (bool wygrana, int proby, int pomylki, int odslonieteLitery) OdgadujHaslo(
        string wylosowaneHaslo,
        string hasloDoWyswietlenia,
        int liczbaNieLiter,
        List<string> rysunkiWisielca)
    {
        int liczbaPomylek = 0;
        int liczbaOdslonietychLiter = 0;
        int liczbaProb = 0;

        string uzyteLitery = "";

        bool podpowiedzUzyta = false; // tylko jedna podpowiedź

        while (liczbaOdslonietychLiter < wylosowaneHaslo.Length - liczbaNieLiter)
        {
            Console.Clear();
            Console.WriteLine(hasloDoWyswietlenia);
            Console.WriteLine(rysunkiWisielca[liczbaPomylek]);
            Console.WriteLine($"Użyte litery: {uzyteLitery}");
            Console.WriteLine("Aby użyć jednorazowej podpowiedzi wpisz znak: ?");
            Console.Write("Podaj literę: ");

            string wejscie = Console.ReadLine() ?? "";
            if (wejscie.Length == 0)
                continue;

            // Podpowiedź: komenda "?"
            if (wejscie[0] == '?')
            {
                if (podpowiedzUzyta)
                {
                    Console.WriteLine("Podpowiedź została już wykorzystana.");
                    Thread.Sleep(1200);
                    continue;
                }
                int ods;

                (hasloDoWyswietlenia, ods) = UzyjPodpowiedzi(wylosowaneHaslo, hasloDoWyswietlenia, uzyteLitery);
                liczbaOdslonietychLiter += ods;
                podpowiedzUzyta = true;
                liczbaProb++; // traktujemy jako próbę
                continue;
            }

            char wpisanaLitera = wejscie[0];
            liczbaProb++;

            if (!uzyteLitery.Contains(wpisanaLitera))
            {
                uzyteLitery += wpisanaLitera;

                if (wylosowaneHaslo.Contains(wpisanaLitera) && !hasloDoWyswietlenia.Contains(wpisanaLitera))
                {
                    for (int i = 0; i < wylosowaneHaslo.Length; i++)
                    {
                        if (wylosowaneHaslo[i] == wpisanaLitera)
                        {
                            hasloDoWyswietlenia = hasloDoWyswietlenia.Remove(i, 1);
                            hasloDoWyswietlenia = hasloDoWyswietlenia.Insert(i, wpisanaLitera.ToString());
                            liczbaOdslonietychLiter++;
                        }
                    }
                }
                else
                {
                    liczbaPomylek++;

                    if (liczbaPomylek == rysunkiWisielca.Count - 1)
                    {
                        Console.Clear();
                        Console.WriteLine(rysunkiWisielca[liczbaPomylek]);
                        Console.WriteLine($"Niestety przegrałeś. Hasłem było: '{wylosowaneHaslo}'");
                        return (false, liczbaProb, liczbaPomylek, liczbaOdslonietychLiter);
                    }
                }
            }
            else
            {
                Console.WriteLine("Ta litera została już użyta. Spróbuj ponownie.");
                Thread.Sleep(1200);
            }
        }

        Console.Clear();
        Console.WriteLine(hasloDoWyswietlenia);
        Console.WriteLine($"Brawo! Wygrałeś. Hasło: '{wylosowaneHaslo}'");
        return (true, liczbaProb, liczbaPomylek, liczbaOdslonietychLiter);
    }
}