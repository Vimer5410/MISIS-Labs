namespace DefaultNamespace;

public class WarriorEquipmentFactory : IEquipmentFactory
{
    public IWeapon CreateWeapon() => new Sword();
    public IArmor CreateArmor() => new HeavyArmor();
}