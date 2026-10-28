using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata.Ecma335;
class Chatbot {
      static void Main()
    {
      bool uruchom = true;
      Console.WriteLine("Chun Li: Witaj Jonesy!!!");
      while (uruchom)
      {
          Console.Write("Ty: ");
          string tekst = Console.ReadLine().ToLower();
          if(tekst == null || typeof(tekst) != typeof(string))
            {
                Console.WriteLine("Chun Li: Naucz się pisać");
                return;
            }
          int klucz = ZnajdzKlucz(tekst);
          if(klucz < 0)
        {
          Console.WriteLine("Chun Li:  Powtórz co powiedziałeś, ja rozumiem język leczenia i broni");
        }
        else
        {
          WyswietlOdpowiedz(klucz);
          if(klucz == 0)
          {
            uruchom = false;
          }
        }
      }
    }

    static string[][] slowaKluczowe = new string[][]
    // stwórz macierz słów kluczy
    {
      new string[]  {"exit", "wyjscie", "papa"},
      new string[]  {"pik", "lik", "nik"},
      new string[]  {"las", "pas", "mas"},
    };

    static string[] odpowiedzi = new string[] {
        "Do widzenia ",
        "Super 2",
        "Super 3"};
  static int ZnajdzKlucz(string odpowiedzUzytkownika)
    // Napisz funckje do przeszukiwania macierzy
    {
      for(int i = 0; i < slowaKluczowe.Length; i++)
      {
        foreach(var klucz in slowaKluczowe[i])
        {
        if (odpowiedzUzytkownika.Contains(klucz))
          {
            return i; // zwracamy indeks jako klucz
          }
        }
      }
      return -1;
    }

    static void WyswietlOdpowiedz(int klucz)
    // Wypisz odp
    {
      Console.WriteLine("Chun Li: " + odpowiedzi[(klucz)]);
    }
}