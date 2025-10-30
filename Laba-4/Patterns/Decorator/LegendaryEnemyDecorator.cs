using Laba_4.Patterns.Common;
using System;

namespace Laba_4.Patterns.Decorator; 

public class LegendaryEnemyDecorator : BaseEnemyDecorator
{
    private const int AdditionalDamage = 20;

    // Обязательный вызов base(wrapee)
    public LegendaryEnemyDecorator(Enemy wrapee) : base(wrapee) { }

    public override string Name => $"Легендарный {_wrapee.Name}";

    // Добавляем новое поведение
    public override void Attack(PlayableCharacter player)
    {
        _logger.Log($"[DECORATOR] {Name} атакует и наносит доп. {AdditionalDamage} урона!");
        base.Attack(player); // 1. Выполняем оригинальную атаку
        
        // 2. Добавляем свою логику
        if (player.IsAlive)
        {
            player.TakeDamage(AdditionalDamage); 
        }
    }
}