using System.ComponentModel.DataAnnotations;

namespace Klasy;

class Film
{
    // Pola (cech)
    public string Tytul;
    public string Gatunek;
    public int Rok;

    //Konstruktor 
    public Film(string tytul, string gatunek, int rok)
    {
        Tytul = tytul;
        Gatunek = gatunek;
        Rok = rok%4;
    } 
    // Metody 
    public void watched()
    {
        Console.WriteLine($"Obejrzałem {Tytul} ");
    }
}
