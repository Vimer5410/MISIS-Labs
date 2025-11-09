using Laba5.Patterns.Common;

namespace Laba5.Patterns.Strategy
{
    // 1. Интерфейс Стратегии
    public interface IAttackStrategy
    {
        void Execute(Enemy enemy);
    }
}