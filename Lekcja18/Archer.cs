namespace Hero;

class Łucznik : Hero
{
    public Łucznik(string imie) : base(imie, maxhp: 85, attackpower: 12){}

    public override void Attack()
    {
        Console.WriteLine("Wystrzeliłem strzałę");
    }
}