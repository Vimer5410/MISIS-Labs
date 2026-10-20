using System;
using Laba_4.Patterns.Common;

namespace Laba_4.Patterns.Common
{
    // все тот же шлак из 3 лабы с помощью билдера
    public class PlayableCharacter
    {
        
        public string Name { get; private set; } = null!;
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        
        private IWeapon _weapon = null!; 
        private IArmor _armor = null!;
        private GameLogger _logger = GameLogger.Instance;

        private PlayableCharacter() { }

        public void Attack(Enemy enemy)
        {
            if (!enemy.IsAlive)
            {
                _logger.Log($"[BATTLE] {enemy.Name} уже побежден.");
                return;
            }
            _logger.Log($"[BATTLE] {Name} атакует {enemy.Name} с помощью {_weapon.Name}, нанося {_weapon.Damage} урона!");
            enemy.TakeDamage(_weapon.Damage);
        }

        public void TakeDamage(int damage)
        {
            int blockedDamage = Math.Min(_armor.Defense, damage);
            int actualDamage = damage - blockedDamage;
            Health -= actualDamage;
            
            _logger.Log($"[BATTLE] {Name} получает {actualDamage} урона (заблокировано: {blockedDamage}). Осталось HP: {Health}");
            if (!IsAlive)
            {
                _logger.Log($"[BATTLE] {Name} был побежден...");
            }
        }

        public override string ToString() => 
            $"{Name} (HP: {Health}) [Оружие: {_weapon.Name}, Броня: {_armor.Name}]";

        public class Builder
        {
            private readonly PlayableCharacter _character = new PlayableCharacter();

            public Builder SetName(string name)
            {
                _character.Name = name;
                return this;
            }
            
            public Builder SetHealth(int health)
            {
                _character.Health = health;
                return this;
            }

            public Builder SetWeapon(IWeapon weapon)
            {
                _character._weapon = weapon;
                return this;
            }

            public Builder SetArmor(IArmor armor)
            {
                _character._armor = armor;
                return this;
            }

            public PlayableCharacter Build()
            {
                GameLogger.Instance.Log($"[Builder] Создан персонаж: {_character.Name}");
                return _character;
            }
        }
    }
}
