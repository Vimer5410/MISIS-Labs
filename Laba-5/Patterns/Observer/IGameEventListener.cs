using Laba5.Patterns.Common;

namespace Laba5.Patterns.Observer
{
    public interface IGameEventListener
    {
        void Update(GameEvent eventType, PlayerProfile playerProfile);
    }
}