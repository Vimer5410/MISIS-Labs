using System;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Chain
{
    // 3c. Конкретный Обработчик
    public class BuffDebuffDamageHandler : AbstractDamageHandler
    {
        private readonly float _multiplier;

        public BuffDebuffDamageHandler(float multiplier) => _multiplier = multiplier;

        public override int Handle(int incomingDamage)
        {
            _logger.Log($"[CHAIN] Применен множитель x{_multiplier} к урону {incomingDamage}.");
            int modifiedDamage = (int)Math.Round(incomingDamage * _multiplier);
            _logger.Log($"[CHAIN] Урон стал {modifiedDamage}.");

            // Передаем *измененный* урон дальше по цепи
            return base.Handle(modifiedDamage);
        }
    }
}