// ==========================================
// 📚 ŚCÍGAWKA ZE STRUKTUR DANYCH W C#
// ==========================================

/* 
🔄 Kolejka (Queue<T>) — Zasada FIFO
// First In, First Out (Kto pierwszy, ten lepszy - np. kolejka do kasy)
*/

// Tworzenie kolejki
Queue<string> kolejka = new Queue<string>();

// Dodawanie elementu na KONIEC kolejki
kolejka.Enqueue("Element");

// Pobieranie i USUNIĘCIE elementu z POCZĄTKU kolejki
string pierwszy = kolejka.Dequeue();

// Sprawdzenie, ile elementów czeka w kolejce
int ile = kolejka.Count;


/*
2. 🥞 Stos (Stack<T>) — Zasada LIFO
// Last In, First Out (Ostatni wchodzi, pierwszy wychodzi - np. stos talerzy)
*/

// Tworzenie stosu
Stack<string> stos = new Stack<string>();

// Dodawanie elementu na SAMĄ GÓRĘ stosu
stos.Push("Element");

// ZDEJMOWANIE i usunięcie elementu z SAMEJ GÓRY
string szczyt = stos.Pop();

// PODGLĄDANIE elementu na górze (BEZ usuwania go)
string podglad = stos.Peek();

// Sprawdzenie liczby elementów
int licz = stos.Count;

/* 
📖 Słownik (Dictionary<TKey, TValue>) — Klucz i Wartość
Przechowuje pary: unikalny Klucz -> Wartość (np. Słowo i definicja)
*/

// Tworzenie słownika (Klucz to string, Wartość to int)
Dictionary<string, int> slownik = new Dictionary<string, int>();

// Dodawanie elementu (Klucz, Wartość)
slownik.Add("Klucz", 100);
slownik["InnyKlucz"] = 50; // Inny sposób dodawania/podmieniania

// Sprawdzanie, czy dany Klucz istnieje w słowniku (zwraca true/false)
bool czyIstnieje = slownik.ContainsKey("Klucz");

// Pobieranie wartości po kluczu
int wartosc = slownik["Klucz"];

/*
🎯 Zbiór (HashSet<T>) — Unikalne elementy
// Magiczna kolekcja, która AUTOMATYCZNIE odrzuca duplikaty
*/

// Tworzenie zbioru
HashSet<string> zbior = new HashSet<string>();

// Dodawanie elementu 
// (Zwraca true, jeśli się udało; false, jeśli element już tam był!)
bool dodano = zbior.Add("Element");
zbior.Add("Element"); // Zwykłe dodanie

// Sprawdzenie czy element znajduje się w zbiorze
bool czyMa = zbior.Contains("Element");

// Liczba unikalnych elementów
int masz = zbior.Count;
