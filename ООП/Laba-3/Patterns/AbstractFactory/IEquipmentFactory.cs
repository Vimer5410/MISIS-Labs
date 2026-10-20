namespace DefaultNamespace;

public interface IEquipmentFactory
{
    IWeapon CreateWeapon();
    IArmor CreateArmor();
}