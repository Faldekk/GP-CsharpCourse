namespace wszystko;
abstract class Hero
{
   // hp, imie, id, maxhp
   public int Hp;
   public string Imie;
   public int Maxhp;
   public int AttackPower;

    protected Hero(string imie, int maxhp, int attackpower)
    {
        Maxhp = maxhp;
        Hp = maxhp;
        Imie = imie;
        AttackPower = attackpower;
    }
    public int HpPercent()
    {
        return (Hp / Maxhp) * 100; }
    public void TakeDamage(int dmg){
        Hp -= dmg;
        if(Hp < 0) Hp = 0;
    }
    public void Info(){
        Console.WriteLine($"Imie {Imie}, DMG {AttackPower} HP: {HpPercent()}");
    }
    public abstract void Attack();
    public virtual void Defend() {Console.WriteLine("Zasłaniam się ręką");}
}

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

class Łucznik : Hero
{
    public Łucznik(string imie) : base(imie, maxhp: 85, attackpower: 12){}

    public override void Attack()
    {
        Console.WriteLine("Wystrzeliłem strzałę");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Hero knight = new Wojownik("Lancelot");
        Hero Bard_Łucznik = new Łucznik("Merida");
        Bard_Łucznik.Info();
        knight.Info();
        knight.Attack();
        Bard_Łucznik.TakeDamage(20);
    }
}