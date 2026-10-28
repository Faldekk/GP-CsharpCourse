namespace Klasy;

class Gracz
{
    public int hp;
    public string imie;
    public Gracz(int HP, string Imie)
    {
        hp = HP;
        imie = Imie;
    }
    public void zaatak()
    {
        hp-=10;
    }
}