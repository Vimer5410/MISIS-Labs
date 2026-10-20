namespace DefaultNamespace;

public class Character
{
    public string Name { get; private set; }
    public string Class { get; private set; }
    public int Health { get; private set; }
    public int Damage { get; private set; }

    private Character() { }

    public class Builder
    {
        private readonly Character _character = new Character();

        public Builder SetName(string name)
        {
            _character.Name = name;
            return this;
        }

        public Builder SetClass(string characterClass)
        {
            _character.Class = characterClass;
            return this;
        }

        public Builder SetHealth(int health)
        {
            _character.Health = health;
            return this;
        }

        public Builder SetDamage(int damage)
        {
            _character.Damage = damage;
            return this;
        }

        public Character Build()
        {
            Logger.Instance.Log($"[Builder] Создан персонаж: {_character.Name}, класс: {_character.Class}");
            return _character;
        }
    }

    public override string ToString() => 
        $"{Name} ({Class}) - HP: {Health}, DMG: {Damage}";
}

