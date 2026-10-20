using System; 
using Laba_4.Patterns.Common;

namespace Laba_4.Patterns.Common
{
    public abstract class Enemy
    {
        
        public virtual string Name { get; protected set; } = null!; 
        public virtual int Health { get; protected set; }
        public virtual int BaseDamage { get; protected set; }
        public bool IsAlive => Health > 0;

        protected GameLogger _logger = GameLogger.Instance;

        public virtual void Attack(PlayableCharacter player)
        {
            _logger.Log($"[BATTLE] {Name} атакует {player.Name}, нанося {BaseDamage} урона!");
            player.TakeDamage(BaseDamage);
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            _logger.Log($"[BATTLE] {Name} получает {damage} урона. Осталось HP: {Health}");
            if (!IsAlive)
            {
                _logger.Log($"[BATTLE] {Name} побежден!");
            }
        }

        public override string ToString() => $"{Name} (HP: {Health})";
    }
}