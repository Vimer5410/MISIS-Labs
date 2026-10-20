using Laba5.Patterns.Common;

namespace Laba5.Patterns.Strategy
{
    
    public interface IAttackStrategy
    {
        void Execute(Enemy enemy);
    }
}