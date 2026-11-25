namespace Hero;

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