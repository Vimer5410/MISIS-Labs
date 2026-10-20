namespace Laba2;

public abstract class Animal : IPet
{
    private readonly string _name;
    protected Animal(string name)
    {
        _name = name;
    }

    public abstract void MakeNoise();

    public string GetName()
    {
        return _name;
    }
}