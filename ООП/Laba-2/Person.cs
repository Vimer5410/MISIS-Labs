namespace Laba2;

public class Person
{
    private IPet _pet;
    private readonly string _name;

    public Person(IPet pet, string name)
    {
        _pet = pet;
        _name = name;
    }

    public void SetPet(IPet pet)
    {
        _pet = pet;
    }

    public void GetPetInfo()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"Pet for {_name} is named {_pet.GetName()}");
        Console.WriteLine("And it sounds like this:");
        _pet.MakeNoise();
        Console.WriteLine("--------------------");
    }
}