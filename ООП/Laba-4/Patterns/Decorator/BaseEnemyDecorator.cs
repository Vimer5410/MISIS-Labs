using Laba_4.Patterns.Common; 

namespace Laba_4.Patterns.Decorator;

public abstract class BaseEnemyDecorator : Enemy
{
    protected Enemy _wrapee; 

    public BaseEnemyDecorator(Enemy wrapee)
    {
        _wrapee = wrapee;
        // мы не устанавливаем Name, Health, Damage, потому что они делегируются
        // но Enemy требует, чтобы они были инициализированы.
        // передаем ответственность за инициализацию базового класса конструктору.
    }

    // переопределяем Name, Health, Damage, чтобы они делегировали вызовы обернутому объекту
    public override string Name => _wrapee.Name;

    // в декораторе мы не даем set, только get, чтобы избежать ошибки CS1540
    public override int Health => _wrapee.Health;
    
    public override int BaseDamage => _wrapee.BaseDamage;

    public override void Attack(PlayableCharacter player)
    {
        _wrapee.Attack(player);
    }

    public override void TakeDamage(int damage)
    {
        _wrapee.TakeDamage(damage);
    }
}