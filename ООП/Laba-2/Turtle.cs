namespace Laba2;

public class Turtle : Animal
{
    public Turtle(string name) : base(name)
    {
    }

    public override void MakeNoise()
    {
        Console.WriteLine("Черепаха");
        
    }
}