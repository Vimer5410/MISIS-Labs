namespace Laba5.Patterns.Command
{
    // 1. Интерфейс Команды
    public interface ICommand
    {
        void Execute();
        // void Undo(); // Можно добавить для отмены
    }
}