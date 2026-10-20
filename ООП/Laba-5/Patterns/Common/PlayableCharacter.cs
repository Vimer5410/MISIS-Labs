using System;

namespace Laba5.Patterns.Common
{
    // получаетль для паттерна command
    public class PlayableCharacter
    {
        public string Name { get; set; } = "Player";
        public int Health { get; private set; } = 100;
        public bool IsAlive => Health > 0;
        private readonly GameLogger _logger = GameLogger.Instance;

        public void TakeDamage(int damage)
        {
            Health -= damage;
            _logger.Log($"[PLAYER] {Name} получил {damage} урона. HP: {Health}");
        }

        //  методы для Command 
        public void Heal(int amount)
        {
            Health += amount;
            _logger.Log($"[PLAYER] {Name} исцелился на {amount}. HP: {Health}");
        }

        public void ApplyBuff(string buffName)
        {
            _logger.Log($"[PLAYER] На {Name} наложен бафф: {buffName}");
        }
    }
}