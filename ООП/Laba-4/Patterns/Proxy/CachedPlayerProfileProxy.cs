using System.Collections.Generic;
using Laba_4.Patterns.Common; 

namespace Laba_4.Patterns.Proxy
{
    
    public class CachedPlayerProfileProxy : IPlayerProfileRepository
    {
        // ссылка на реальный, "медленный" объект
        private readonly PlayerProfileRepository _realService;
        // хранилище для кешированных данных
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();
        private readonly GameLogger _logger = GameLogger.Instance;

        public CachedPlayerProfileProxy()
        {
            // создаем реальный объект
            _realService = new PlayerProfileRepository();
        }

        public string GetProfileData(string playerId)
        {
            // проверяем кеш
            if (_cache.ContainsKey(playerId))
            {
                _logger.Log($"[PROXY] Данные для {playerId} взяты из кеша. Мгновенно!");
                return _cache[playerId];
            }

            //если данных нет   вызываем Real Service (долгий вызов)
            _logger.Log($"[PROXY] Кеш промахнулся. Вызываю Real Service...");
            string data = _realService.GetProfileData(playerId);

            //  к ешируем полученный результат
            _cache.Add(playerId, data);
            _logger.Log($"[PROXY] Данные для {playerId} успешно добавлены в кеш.");
            
            return data;
        }
    }
}