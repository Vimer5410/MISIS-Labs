using System;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Chain
{
    // 3b. Конкретный Обработчик
    public class BarrierDamageHandler : AbstractDamageHandler
    {
        private int _barrierHealth;

        public BarrierDamageHandler(int barrierHealth) => _barrierHealth = barrierHealth;

        public override int Handle(int incomingDamage)
        {
            if (_barrierHealth <= 0 || incomingDamage <= 0)
            {
                // Если щита нет или урон уже 0, просто передаем дальше
                return base.Handle(incomingDamage);
            }

            _logger.Log($"[CHAIN] Барьер ({_barrierHealth} HP) поглощает урон...");
            
            int damageToPass = Math.Max(0, incomingDamage - _barrierHealth);
            _barrierHealth = Math.Max(0, _barrierHealth - incomingDamage);
            
            _logger.Log($"[CHAIN] Барьер. Оставшийся урон: {damageToPass}. HP щита: {_barrierHealth}");
            
            // Передаем *оставшийся* урон дальше по цепи
            return base.Handle(damageToPass);
        }
    }
}