using System;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Observer
{
    // второй   подписчик
    public class GameUpdaterEventListener : IGameEventListener
    {
        private readonly IPlayerProfileRepository _repository;

        public GameUpdaterEventListener(IPlayerProfileRepository repository)
        {
            _repository = repository;
        }

        public void Update(GameEvent eventType, PlayerProfile playerProfile)
        {
            if (eventType == GameEvent.GAME_OVER)
            {
                GameLogger.Instance.Log($"[OBSERVER-UPDATE] Обнаружен GAME_OVER. Сбрасываю счет.");
                _repository.UpdateHighScore(playerProfile.Name, 0);
            }
        }
    }
}