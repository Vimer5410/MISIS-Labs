using System;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Observer
{
    // 3a. Конкретный Подписчик 1
    public class GameConsoleEventListener : IGameEventListener
    {
        public void Update(GameEvent eventType, PlayerProfile playerProfile)
        {
            GameLogger.Instance.Log(
                $"[OBSERVER-LOG] Событие: {eventType} для игрока {playerProfile.Name}.");
        }
    }
}