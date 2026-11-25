namespace Hero;

class Wojownik : Hero
{
    public Wojownik(string imie) : base(imie, maxhp: 120, attackpower: 16){}

    public override void Attack()
    {
        Console.WriteLine("Machnąłem Mieczem");
    }
    public override void Defend()
    {
        base.Defend();
        Console.WriteLine("Dodał miecz do obrony i kontraataku");
    }
}