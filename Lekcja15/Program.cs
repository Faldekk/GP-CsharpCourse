using System;
using System.Collections.Generic;
using System.Threading;

static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Queue<string> petycjonariusze = new Queue<string>();
        petycjonariusze.Enqueue("Pan Stanisław (przyszedł tylko o coś zapytać)");
        petycjonariusze.Enqueue("Pani Krysia (ma źle wypełniony wniosek na żółtym druku A-38)");
        petycjonariusze.Enqueue("Student, który myślał, że można przez Internet");
        petycjonariusze.Enqueue("Pan Eugeniusz (szuka kierownika, bo nie działa winda)");

        Console.WriteLine("🏛️ WITAJ W URZĘDZIE MIEJSKIM (Wydział Spraw Niewyjaśnionych)");
        Console.WriteLine($"Aktualna długa kolejka: {petycjonariusze.Count} osób.\n");
        Thread.Sleep(1500);

        int numerBiletiku = 42;

        while (petycjonariusze.Count > 0)
        {
            string nastepny = petycjonariusze.Dequeue();
            numerBiletiku++;

            Console.Beep(800, 300); // Mały dźwiękowy pikacz z głośniczka systemowego (o ile działa)
            Console.WriteLine($"📢 Z GŁOŚNIKÓW: Osoba z biletikiem numer [ {numerBiletiku} ] do pokoju 104!");
            Console.WriteLine($"   -> Przy okienku pojawia się: {nastepny}"); 
            Thread.Sleep(2000);

            Random rnd = new Random();
            int los = rnd.Next(1, 4);

            if (los == 1)
            {
                Console.WriteLine("❌ URZĘDNIK: 'Proszę pana, dzisiaj jest poniedziałek, a w poniedziałki okienko 3 jest nieczynne.'");
                Console.WriteLine("   -> Interesant wraca na koniec kolejki z płaczem.\n");
                petycjonariusze.Enqueue(nastepny + " (wkurzony po raz drugi)");
            }
            else if (los == 2)
            {
                Console.WriteLine("☕ URZĘDNIK: 'Przepraszam, mamy przerwę kawową na 40 minut.'");
                Console.WriteLine("   -> Wszyscy w kolejce wzdychają ciężko w tym samym rytmie.\n");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("✅ Sukces! Sprawa załatwiona pieczątką w 3 sekundach.\n");
            }

            if (petycjonariusze.Count > 0)
            {
                Console.WriteLine($"[Kolejka zmniejszyła się. Zostało osób: {petycjonariusze.Count}]\n");
                Console.WriteLine("--------------------------------------------------");
                Thread.Sleep(1000);
            }
        }

        Console.WriteLine("🎉 KATASTROFA! W urzędzie skończyły się numerki i wyłączyli prąd o 14:59. Koniec pracy na dziś!");
    }