using System;
using System.Collections.Generic;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Observer
{
    // 2. Издатель (Subject)
    public class GameEventPublisher
    {
        private readonly Dictionary<GameEvent, List<IGameEventListener>> _listeners = new();
        private readonly GameLogger _logger = GameLogger.Instance;

        public void Subscribe(GameEvent typeToSubscribeTo, IGameEventListener subscriber)
        {
            if (!_listeners.ContainsKey(typeToSubscribeTo))
            {
                _listeners[typeToSubscribeTo] = new List<IGameEventListener>();
            }
            _listeners[typeToSubscribeTo].Add(subscriber);
            _logger.Log($"Подписчик {subscriber.GetType().Name} подписан на {typeToSubscribeTo}.");
        }

        public void NotifyAll(GameEvent notifyEventType, PlayerProfile playerProfile)
        {
            _logger.Log($"\n[EVENT] Инициировано событие: {notifyEventType}");
            if (!_listeners.ContainsKey(notifyEventType)) return;

            // Мы копируем список, чтобы избежать проблем, если подписчик отпишется
            // прямо во время получения уведомления
            foreach (var listener in new List<IGameEventListener>(_listeners[notifyEventType]))
            {
                listener.Update(notifyEventType, playerProfile);
            }
        }
    }
}