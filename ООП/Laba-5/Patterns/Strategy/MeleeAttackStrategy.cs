using System;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Strategy
{
    
    public class MeleeAttackStrategy : IAttackStrategy
    {
        public void Execute(Enemy enemy)
        {
            GameLogger.Instance.Log("Компаньон атакует в ближнем бою!");
            enemy.TakeDamage(10);
        }
    }
}