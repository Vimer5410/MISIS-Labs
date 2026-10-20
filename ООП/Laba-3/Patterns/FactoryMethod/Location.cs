namespace DefaultNamespace;

public abstract class Location
{
    public string Name { get; protected set; }

    public void Enter()
    {
        Logger.Instance.Log($"[Factory Method] Вход в локацию: {Name}");
        Enemy enemy = SpawnEnemy();
        Logger.Instance.Log($"[Factory Method] Появился враг: {enemy}");
    }

    // переопределяется в подклассах, FabricMethod ???
    protected abstract Enemy SpawnEnemy();
}