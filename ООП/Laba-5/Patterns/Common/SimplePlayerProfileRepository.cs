using System.Collections.Generic;

namespace Laba5.Patterns.Common
{
    public class SimplePlayerProfileRepository : IPlayerProfileRepository
    {
        private readonly Dictionary<string, PlayerProfile> _profiles = new();

        public PlayerProfile GetProfile(string name)
        {
            if (!_profiles.ContainsKey(name))
            {
                _profiles[name] = new PlayerProfile { Name = name };
            }
            return _profiles[name];
        }

        public void UpdateHighScore(string name, int newScore)
        {
            var profile = GetProfile(name);
            // Логика из лабника: сброс счета до 0
            if (newScore == 0)
            {
                profile.Score = 0;
                GameLogger.Instance.Log($"Счет игрока {name} сброшен до 0.");
            }
            else if (newScore > profile.Score)
            {
                profile.Score = newScore;
                GameLogger.Instance.Log($"Обновлен счет игрока {name} до {newScore}.");
            }
        }
    }
}