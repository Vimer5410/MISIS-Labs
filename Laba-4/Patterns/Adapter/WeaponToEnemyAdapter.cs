using Laba_4.Patterns.Common; 
using System;

namespace Laba_4.Patterns.Adapter;

// адаптер, который позволяет оружию быть как энеми
public class WeaponToEnemyAdapter : Enemy
{
    private readonly IWeapon _weapon;
    
    // переопределяю имя,  чтобы оно отражало адаптированный объект
    public override string Name => $"Адаптированное оружие ({_weapon.Name})";

    public WeaponToEnemyAdapter(IWeapon weapon)
    {
        _weapon = weapon;
        
        BaseDamage = _weapon.Damage / 2; 
        Health = _weapon.Damage * 3;     
        GameLogger.Instance.Log($"[ADAPTER] Оружие {_weapon.Name} адаптировано в 'врага' (HP: {Health}, Урон: {BaseDamage})");
    }

   
    public override void Attack(PlayableCharacter player)
    {
        GameLogger.Instance.Log($"[ADAPTER] Оружие {_weapon.Name} наносит удар!");
        player.TakeDamage(BaseDamage);
    }
    
    
    public override void TakeDamage(int damage)
    {
        Health -= damage;
        _logger.Log($"[ADAPTER] Оружие получает {damage} урона. Прочность: {Health}");
    }
}