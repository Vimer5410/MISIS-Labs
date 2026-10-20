namespace DefaultNamespace;

public class MageEquipmentFactory : IEquipmentFactory
{
    public IWeapon CreateWeapon() => new Staff();
    public IArmor CreateArmor() => new Robe();
}