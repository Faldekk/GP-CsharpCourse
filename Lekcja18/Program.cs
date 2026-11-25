namespace Hero;

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
