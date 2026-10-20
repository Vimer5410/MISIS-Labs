namespace DefaultNamespace;

public class Forest : Location
{
    public Forest()
    {
        Name = "Лес";
    }

    protected override Enemy SpawnEnemy() => new Goblin();
}