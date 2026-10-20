namespace Laba5.Patterns.Common
{
    public interface IPlayerProfileRepository
    {
        PlayerProfile GetProfile(string name);
        void UpdateHighScore(string name, int newScore);
    }
}