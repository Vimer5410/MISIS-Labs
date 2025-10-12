namespace Laba2;

public class Parrot : Animal
{
    public Parrot(string name) : base(name)
    {
    }

    public override void MakeNoise()
    {
        Console.WriteLine("Попугай");
    }
}