using System.Collections.Generic;
using Laba5.Patterns.Common;

namespace Laba5.Patterns.Command
{
    // тот кто вызывает
    public class CommandProcessor
    {
        private readonly Queue<ICommand> _commandQueue = new Queue<ICommand>();
        private readonly GameLogger _logger = GameLogger.Instance;

        // добавляем команду в очередь на выполнение
        public void AddCommand(ICommand command)
        {
            _logger.Log($"[COMMAND] Команда {command.GetType().Name} добавлена в очередь.");
            _commandQueue.Enqueue(command);
        }

        // выполняем все команды в очереди
        public void ProcessCommands()
        {
            _logger.Log($"\n[COMMAND] --- Обработка очереди команд ---");
            while (_commandQueue.Count > 0)
            {
                ICommand command = _commandQueue.Dequeue();
                _logger.Log($"[COMMAND] Выполнение {command.GetType().Name}...");
                command.Execute();
            }
            _logger.Log($"[COMMAND] --- Очередь команд пуста ---");
        }
    }
}