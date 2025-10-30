namespace Laba_4.Patterns.Common
{
    // а тут абстрактная фабрика, тоже из 3 лабы
    public interface IEquipmentFactory
    {
        IWeapon CreateWeapon();
        IArmor CreateArmor();
    }
}