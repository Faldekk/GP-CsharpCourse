namespace StrukturyDanych;

class Lekcja
{
    public static void Function_Queue()
    {
        Console.WriteLine("=== SYSTEM ALGORYTMU TIKTOKA ===");

        Queue<string> forYouPage = new();
        forYouPage.Enqueue("Kot grający na pianinie");
        forYouPage.Enqueue("Śmieszny fail na deskorolce");
        forYouPage.Enqueue("Porady jak zdać matmę");

        Console.WriteLine($"Masz do obejrzenia {forYouPage.Count} filmiki w kolejce.\n");

        // Pętla symulująca przeglądanie aplikacji
        while (forYouPage.Count > 0)
        {
            // TODO 1: Pobierz i usuń z kolejki pierwszy filmik z góry
            // Wskazówka: Użyj metody `.Dequeue()` na obiekcie forYouPage
            string aktualnyFilm = forYouPage.Dequeue();

            Console.WriteLine($"\n📱 Oglądasz teraz: {aktualnyFilm}");

            Console.Write("Chcesz polubić ten film? (t/n): ");
            string akcja = Console.ReadLine();
            if (akcja == "t")
            {
                Console.WriteLine("<3 Polubiono! Algorytm zapisał Twoje preferencje.");
            }

            // KROK 2: Użytkownik wrzuca swój własny film do sieci
            Console.Write("Wrzuć swój film (wpisz tytuł lub wciśnij Enter, aby pominąć): ");
            string nowyFilm = Console.ReadLine();

            if (!string.IsNullOrEmpty(nowyFilm))
            {
                // TODO 2: Dodaj nowy film na KONIEC kolejki algorytmu
                forYouPage.Enqueue("Porady do minecrafta");
                Console.WriteLine($" Twój film '{nowyFilm}' trafił do kolejki algorytmu!");
            }

            Console.WriteLine($"Liczba filmów oczekujących w kolejce: {forYouPage.Count}");

            Console.Write("\nCzy chcesz kontynuować scrollowanie? (t/n): ");
            string kontynuowac = Console.ReadLine();
            if (kontynuowac != "t")
            {
                Console.WriteLine("Zamykasz aplikację. Do zobaczenia jutro!");
                break;
            }
        }

        if (forYouPage.Count == 0)
        {
            Console.WriteLine("Obejrzałeś już wszystkie filmiki w internecie! Czas wyjść na dwór.");
        }
    }
    public static void UruchomPrzegladarke()
    {
        Console.WriteLine("=== HISTORIA PRZEGLĄDARKI (Stos / Stack) ===");
        Stack<string> historiaStron = new();
        historiaStron.Push("Google.com");
        historiaStron.Push("YouTube.com");
        historiaStron.Push("SmieszneKoty.pl");

        Console.WriteLine($"Aktualnie jesteś na stronie: {historiaStron.Peek()}\n");

        while (historiaStron.Count > 1)
        {
            Console.Write("Chcesz kliknąć 'Wstecz'? (t/n): ");
            if (Console.ReadLine() == "t")
            {
                string zamknietaStrona = historiaStron.Pop();
                Console.WriteLine($"🔙 Wracasz! Zamknięto: {zamknietaStrona}");
                Console.WriteLine($"Teraz jesteś na stronie: {historiaStron.Peek()}");
            }
            else
            {
                Console.Write("Wpisz adres nowej strony, którą chcesz odwiedzić: ");
                string nowaStrona = Console.ReadLine();
                if (!string.IsNullOrEmpty(nowaStrona))
                {
                    // TODO 2: Dodaj nową stronę na szczyt stosu (Użyj .Push(nowaStrona))
                    historiaStron.Push(nowaStrona);
                    Console.WriteLine($" Przeszedłeś do: {nowaStrona}");
                }
            }
        }
        Console.WriteLine("\nDotarłeś do bazy historii. Wciśnij Enter, aby wrócić do menu.");
        Console.ReadKey();
    }
    public static void UruchomEkwipunek()
    {
        Console.WriteLine("=== EKWIPUNEK GRACZA (Słownik / Dictionary) ===");
        Dictionary<string, int> eq = new()
        {
            { "Mikstura Zdrowia", 3 },
            { "Złote Monety", 150 },
            { "Drewniany Miecz", 1 }
        };

        Console.WriteLine("Twoje przedmioty:");
        foreach (var item in eq)
        {
            Console.WriteLine($"- {item.Key}: {item.Value} szt.");
        }

        Console.Write("\nWpisz nazwę przedmiotu do sprawdzenia/dodania: ");
        string szukanyPrzedmiot = Console.ReadLine();

        // TODO 1: Sprawdź czy słownik zawiera już taki klucz (Użyj .ContainsKey(szukanyPrzedmiot))
        bool czyJest = eq.ContainsKey(szukanyPrzedmiot); 

        if (czyJest)
        {
            Console.WriteLine($"Masz już ten przedmiot! Posiadasz sztuk: {eq[szukanyPrzedmiot]}");
        }
        else
        {
            eq[szukanyPrzedmiot] = 5;
            Console.WriteLine($"Nowy przedmiot {szukanyPrzedmiot} dodany do ekwipunku!");
        }

        Console.WriteLine("\nWciśnij Enter, aby wrócić do menu.");
        Console.ReadKey();
    }
   public static void UruchomZnajomych()
    {
        Console.WriteLine("=== LISTA ZNAJOMYCH (Zbiór / HashSet) ===");
        HashSet<string> znajomi = ["ProGamer99", "KubaKox", "AniaSkacze"];

        Console.WriteLine($"Twoi znajomi online ({znajomi.Count}):");
        foreach (var znajomy in znajomi)
        {
            Console.WriteLine($"- {znajomy}");
        }

        Console.Write("\nWpisz nick osoby, którą chcesz zaprosić: ");
        string nowyZnajomy = Console.ReadLine();

        // TODO 1: Spróbuj dodać znajomego do zbioru (Użyj znajomi.Add(nowyZnajomy) - zwraca true lub false)
        bool sukces = true; // WPISZ KOD TUTAJ

        if (sukces)
        {
            Console.WriteLine($"Pomyślnie dodano gracza {nowyZnajomy}!");
        }
        else
        {
            Console.WriteLine($"Ten gracz ({nowyZnajomy}) jest już na liście! (Brak duplikatów).");
        }

        Console.WriteLine($"\nŁącznie unikalnych znajomych: {znajomi.Count}");
        Console.WriteLine("\nWciśnij Enter, aby wrócić do menu.");
        Console.ReadKey();
    }

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("   WYBIERZ STRUKTURĘ DANYCH DO TESTU   ");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Kolejka (Queue) - Algorytm Tiktoka");
            Console.WriteLine("2. Stos (Stack) - Historia Przeglądarki");
            Console.WriteLine("3. Słownik (Dictionary) - Ekwipunek Gry");
            Console.WriteLine("4. Zbiór (HashSet) - Lista Znajomych");
            Console.WriteLine("0. Wyjście");
            Console.WriteLine("======================================");
            Console.Write("Wybierz opcję (0-4): ");

            string wybor = Console.ReadLine();
            Console.Clear();

            switch (wybor)
            {
                case "1":
                    Function_Queue();
                    break;
                case "2":
                    UruchomPrzegladarke();
                    break;
                case "3":
                    UruchomEkwipunek();
                    break;
                case "4":
                    UruchomZnajomych();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nie ma takiej opcji! Wciśnij Enter, aby spróbować ponownie.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}