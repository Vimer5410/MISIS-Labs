using Laba_4.Patterns.Common; 
using System.Threading;

namespace Laba_4.Patterns.Proxy
{
    // реальный объект (Real Subject), который выполняет долгую операцию
    public class PlayerProfileRepository : IPlayerProfileRepository
    {
        private readonly GameLogger _logger = GameLogger.Instance;

        public string GetProfileData(string playerId)
        {
            _logger.Log($"[REAL SERVICE] Запрос данных из базы для {playerId}...");
            
            // тмитация задержки (например, сетевого запроса или сложной обработки)
            Thread.Sleep(2000); 

            return $"Профиль {playerId}: Уровень 42, Золото 1000";
        }
    }
}