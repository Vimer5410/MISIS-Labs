namespace DefaultNamespace;

public abstract class Enemy
{
    public string Name { get; protected set; }
    public int Health { get; protected set; }

    public override string ToString() => $"{Name} (HP: {Health})";
}