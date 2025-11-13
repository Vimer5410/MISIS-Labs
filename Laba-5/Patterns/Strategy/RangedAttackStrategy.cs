using System;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Strategy
{
    
    public class RangedAttackStrategy : IAttackStrategy
    {
        public void Execute(Enemy enemy)
        {
            GameLogger.Instance.Log("Компаньон атакует издалека!");
            enemy.TakeDamage(7);
        }
    }
}