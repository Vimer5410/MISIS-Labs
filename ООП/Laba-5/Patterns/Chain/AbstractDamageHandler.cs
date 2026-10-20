using Laba5.Patterns.Common;

namespace Laba5.Patterns.Chain
{
    // 2. Абстрактный Обработчик
    public abstract class AbstractDamageHandler : IDamageHandler
    {
        private IDamageHandler? _nextHandler;
        protected GameLogger _logger = GameLogger.Instance;

        public IDamageHandler SetNext(IDamageHandler nextHandler)
        {
            this._nextHandler = nextHandler;
            return nextHandler; // Возвращаем следующего для удобного связывания
        }

        public virtual int Handle(int incomingDamage)
        {
            // Если есть следующий обработчик, передаем ему урон
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(incomingDamage);
            }
            // Если это конец цепи, возвращаем финальный урон
            return incomingDamage;
        }
    }
}