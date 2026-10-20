using Laba_4.Patterns.Common;
using System;

namespace Laba_4.Patterns.Decorator; 

public class WindfuryEnemyDecorator : BaseEnemyDecorator
{
    public WindfuryEnemyDecorator(Enemy wrapee) : base(wrapee) { }

    public override string Name => $"Неистовый {_wrapee.Name}";

    // Полностью изменяем поведение
    public override void Attack(PlayableCharacter player)
    {
        _logger.Log($"[DECORATOR] Неистовство ветра! {Name} атакует дважды!");
        
        base.Attack(player); // Первая атака
        if (player.IsAlive)
        {
            base.Attack(player); // Вторая атака
        }
    }
}