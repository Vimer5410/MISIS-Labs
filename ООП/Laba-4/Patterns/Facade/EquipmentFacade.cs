using Laba_4.Patterns.Common;

namespace Laba_4.Patterns.Facade; 

public class EquipmentFacade
{
    private GameLogger _logger = GameLogger.Instance;

    public (IWeapon, IArmor) GetStartingEquipment(CharacterClass charClass)
    {
        _logger.Log($"[FACADE] Запрос экипировки для класса: {charClass}");
        IEquipmentFactory factory;

        switch (charClass)
        {
            case CharacterClass.WARRIOR:
                factory = new WarriorEquipmentFactory();
                break;
            case CharacterClass.MAGE:
                factory = new MageEquipmentFactory();
                break;
            default:
                throw new ArgumentException("Неизвестный класс");
        }

        IWeapon weapon = factory.CreateWeapon();
        IArmor armor = factory.CreateArmor();
        _logger.Log($"[FACADE] Выдано: {weapon.Name} и {armor.Name}");
            
        return (weapon, armor);
    }
}