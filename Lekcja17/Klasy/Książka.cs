namespace Klasy;

class Book
{
    //Pola
    //Konstruktor
    public string Tytul;
    public string Autor;
    public int Rok;
    public Book(string tytul, string autor, int rok)
    {
        Tytul = tytul;
        Autor = autor;
        Rok = rok;
    }
    public void readtosleep()
    {
        Console.WriteLine($"Przeczytałem {Tytul} autorstwa {Autor} ");
    }
}
