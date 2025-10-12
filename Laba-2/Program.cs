
using Laba2;

class Program
{
    static void Main(string[] args)
    {
        Parrot parrot = new Parrot("Kesha");
        Turtle turtle = new Turtle("Тортилья");
        
        Person jack = new Person(parrot, "Персона1");
        Person john = new Person(turtle, "Персона2");
        
        jack.GetPetInfo();
        john.GetPetInfo();
        
        Console.ReadLine();
    }
}