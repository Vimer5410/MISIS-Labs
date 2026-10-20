namespace DefaultNamespace;

public class Cave : Location
{
    public Cave()
    {
        Name = "Пещера";
    }

    protected override Enemy SpawnEnemy() => new Dragon();
}