using System;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Observer
{
    
    public class GameConsoleEventListener : IGameEventListener
    {
        // первый подписчик на событие
        public void Update(GameEvent eventType, PlayerProfile playerProfile)
        {
            GameLogger.Instance.Log(
                $"[OBSERVER-LOG] Событие: {eventType} для игрока {playerProfile.Name}.");
        }
    }
}