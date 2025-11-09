using System;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Strategy
{
    // 3. Контекст
    public class Companion
    {
        private readonly IAttackStrategy _attackStrategy;
        private static readonly Random Rng = new Random();

        public Companion(CharacterClass companionToClass)
        {
            _attackStrategy = companionToClass switch
            {
                CharacterClass.MAGE => new MeleeAttackStrategy(),
                CharacterClass.WARRIOR => new RangedAttackStrategy(),
                CharacterClass.THIEF => Rng.Next(2) == 0
                    ? (IAttackStrategy)new MeleeAttackStrategy()
                    : new RangedAttackStrategy(),
                _ => throw new ArgumentException("Неизвестный класс")
            };
        }

        public void Attack(Enemy enemy)
        {
            this._attackStrategy.Execute(enemy);
        }
    }
}