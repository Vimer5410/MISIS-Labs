using System;
using Laba5.Patterns.Common;
using Laba5.Patterns.Strategy;
using Laba5.Patterns.Observer;
using Laba5.Patterns.Chain;
using Laba5.Patterns.Command;

namespace Laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем экземпляр логгера
            var logger = GameLogger.Instance;
            
        
            DemonstrateStrategy(logger);

            DemonstrateObserver(logger);

            DemonstrateChain(logger);
            

            DemonstrateCommand(logger);

            Console.WriteLine("\nнажмите Enter для завершения...");
            Console.ReadLine();
        }

        private static void DemonstrateStrategy(GameLogger logger)
        {
            Console.WriteLine("\n=========== 1. Тест Strategy =========");

            // --- ИЗМЕНЕНИЕ ЗДЕСЬ ---
            var enemy = new Enemy("Волк"); // Используем конструктор, а не инициализатор

            // Демонстрация 1: Стратегия для Мага (MeleeAttackStrategy)
            logger.Log("Создание компаньона для MAGE (Ближний бой)...");
            var mageCompanion = new Companion(CharacterClass.MAGE);
            mageCompanion.Attack(enemy);
        }

        private static void DemonstrateObserver(GameLogger logger)
        {
            Console.WriteLine("\n ============= Тест Observer ========");
            
            var publisher = new GameEventPublisher();
            var repository = new SimplePlayerProfileRepository(); 
            var player = repository.GetProfile("кто-то там что там");
            player.Score = 500; 

            var consoleListener = new GameConsoleEventListener();
            var updaterListener = new GameUpdaterEventListener(repository);

            // Подписка двух подписчиков на GAME_OVER
            publisher.Subscribe(GameEvent.GAME_START, consoleListener);
            publisher.Subscribe(GameEvent.GAME_OVER, consoleListener);
            publisher.Subscribe(GameEvent.GAME_OVER, updaterListener);
            
            // Демонстрация ивентов
            publisher.NotifyAll(GameEvent.GAME_START, player);

            logger.Log($"Текущий счет игрока перед проигрышем: {player.Score}");
            publisher.NotifyAll(GameEvent.GAME_OVER, player);
            logger.Log($"Счет игрока после проигрыша: {player.Score}"); 
        }
        
        private static void DemonstrateChain(GameLogger logger)
        {
            Console.WriteLine("\n ========== Тест Chain ==========");
            
            int incomingDamage = 100;
            logger.Log($"Исходный урон: {incomingDamage}");

            // 1. Создаем 3 обработчика
            var buffHandler = new BuffDebuffDamageHandler(1.5f); 
            var barrierHandler = new BarrierDamageHandler(50); 
            var invulnerabilityHandler = new InvulnerabilityDamageHandler(); 

            // 2. Динамическое конструирование цепи: Buff -> Barrier -> Invulnerability
            buffHandler
                .SetNext(barrierHandler)
                .SetNext(invulnerabilityHandler);

            // 3. Запуск обработки
            int finalDamage = buffHandler.Handle(incomingDamage);
            logger.Log($"Итоговый урон после прохождения цепи: {finalDamage}");
        }
        
        private static void DemonstrateCommand(GameLogger logger)
        {
            Console.WriteLine("\n ========= Тест Command");
            
            // 1. Получатель (Receiver)
            var player = new PlayableCharacter { Name = "Hero_CMD" };
            
            // 2. Вызывающий (Invoker)
            var commandProcessor = new CommandProcessor();
            
            // 3. Создаем Конкретные Команды
            var healCommand = new HealCommand(player, 25);
            var buffCommand = new BuffCommand(player, "Берсерк");

            // 4. Добавляем команды в очередь (отложенное выполнение)
            commandProcessor.AddCommand(healCommand);
            commandProcessor.AddCommand(buffCommand);

            logger.Log($"Игрок {player.Name} готовится к бою. HP: {player.Health}");
            
            // 5. Выполняем все отложенные команды
            commandProcessor.ProcessCommands();
            
            logger.Log($"Игрок {player.Name} готов к бою. HP: {player.Health}");
        }
    }
}