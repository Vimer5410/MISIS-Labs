namespace Laba5.Patterns.Chain
{
    // 1. Интерфейс Обработчика
    public interface IDamageHandler
    {
        IDamageHandler SetNext(IDamageHandler nextHandler);
        int Handle(int incomingDamage);
    }
}