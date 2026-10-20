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
            // получаем экземпляр логгера
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

            
            var enemy = new Enemy("Волк"); 

            
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

                // gjlgbcsdftv gjlgbcxbrjd
            publisher.Subscribe(GameEvent.GAME_START, consoleListener);
            publisher.Subscribe(GameEvent.GAME_OVER, consoleListener);
            publisher.Subscribe(GameEvent.GAME_OVER, updaterListener);
            
           
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

            
            var buffHandler = new BuffDebuffDamageHandler(1.5f); 
            var barrierHandler = new BarrierDamageHandler(50); 
            var invulnerabilityHandler = new InvulnerabilityDamageHandler(); 

            
            buffHandler
                .SetNext(barrierHandler)
                .SetNext(invulnerabilityHandler);

            
            int finalDamage = buffHandler.Handle(incomingDamage);
            logger.Log($"Итоговый урон после прохождения цепи: {finalDamage}");
        }
        
        private static void DemonstrateCommand(GameLogger logger)
        {
            Console.WriteLine("\n ========= Тест Command");
            
            // тот кто получает
            var player = new PlayableCharacter { Name = "Hero_CMD" };
            
            // тот кто вызывает
            var commandProcessor = new CommandProcessor();
            
            // 
            var healCommand = new HealCommand(player, 25);
            var buffCommand = new BuffCommand(player, "Берсерк");

            // добьавляю команды в очередь, чтобы они потом вызывались
            commandProcessor.AddCommand(healCommand);
            commandProcessor.AddCommand(buffCommand);

            logger.Log($"Игрок {player.Name} готовится к бою. HP: {player.Health}");
            
            // все отложенные команды выполняю
            commandProcessor.ProcessCommands();
            
            logger.Log($"Игрок {player.Name} готов к бою. HP: {player.Health}");
        }
    }
}