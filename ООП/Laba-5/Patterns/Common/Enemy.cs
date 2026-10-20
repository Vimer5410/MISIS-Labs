using System;

namespace Laba5.Patterns.Common
{
    public class Enemy
    {
        
        public virtual string Name { get; protected set; } = "Гоблин"; 
        public virtual int Health { get; protected set; } = 50;
        public virtual int BaseDamage { get; protected set; } = 5;
        public bool IsAlive => Health > 0;

        protected GameLogger _logger = GameLogger.Instance;
        
        public Enemy() { } 

        public Enemy(string name, int health = 50, int baseDamage = 5)
        {
            Name = name; 
            Health = health;
            BaseDamage = baseDamage;
        }
        
        
        
        

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