using Laba_4.Patterns.Common; 
using Laba_4.Patterns.Facade; 
using Laba_4.Patterns.Decorator; 
using Laba_4.Patterns.Adapter; 
using Laba_4.Patterns.Proxy; 
using System;
using System.Threading;

namespace Laba_4; 

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var logger = GameLogger.Instance;
            logger.Log("=== ДЕМОНСТРАЦИЯ СТРУКТУРНЫХ ПАТТЕРНОВ ===\n");

            // --- 0. Подготовка (Фасад) ---
            logger.Log("--- 0. ПОДГОТОВКА (Тест Фасада) ---");
            EquipmentFacade facade = new EquipmentFacade();
            var (weapon, armor) = facade.GetStartingEquipment(CharacterClass.WARRIOR);
            
            PlayableCharacter player = new PlayableCharacter.Builder()
                .SetName("Конан")
                .SetHealth(200)
                .SetWeapon(weapon)
                .SetArmor(armor)
                .Build();
            logger.Log(player.ToString() + "\n");

            // --- 1. ДЕКОРАТОР ---
            logger.Log("--- 1. ДЕКОРАТОР (Добавляем модификаторы врагу) ---");
            Enemy goblin = new Goblin();
            logger.Log($"Создан обычный враг: {goblin.Name} (HP: {goblin.Health})");
            player.Attack(goblin);
            
            // оборачиваем гоблина в легендарный декоратор
            Enemy legendaryGoblin = new LegendaryEnemyDecorator(goblin);
            logger.Log($"\nВраг стал: {legendaryGoblin.Name}");
            legendaryGoblin.Attack(player); 
            
            // оборачиваем уже обернутого гоблина еще одним декоратором
            Enemy superGoblin = new WindfuryEnemyDecorator(legendaryGoblin);
            logger.Log($"\nВраг стал: {superGoblin.Name}");
            superGoblin.Attack(player); 
            logger.Log("");

            // --- 2. АДАПТЕР ---
            logger.Log("--- 2. АДАПТЕР (Оружие становится Врагом) ---");
            
            
            IWeapon staff = new MageEquipmentFactory().CreateWeapon();
            logger.Log($"Взят предмет: {staff.Name} (Урон: {staff.Damage})");

            // адаптируем IWeapon к типу Enemy
            Enemy adaptedWeapon = new WeaponToEnemyAdapter(staff);
            logger.Log($"Предмет стал врагом: {adaptedWeapon.Name} (HP: {adaptedWeapon.Health})");
            
            player.Attack(adaptedWeapon);
            adaptedWeapon.Attack(player);
            logger.Log("");

            // --- 3. ФАСАД ---
            logger.Log("--- 3. ФАСАД (Упрощение Абстрактной Фабрики) ---");
            logger.Log("Фасад уже был использован в блоке '0. ПОДГОТОВКА'.");
            logger.Log("");

            // --- 4. ЗАМЕСТИТЕЛЬ (ПРОКСИ) ---
            logger.Log("--- 4. ЗАМЕСТИТЕЛЬ (Кеширование данных игрока) ---");
            // клиент работает через интерфейс, имитируем задержку бла бла
            IPlayerProfileRepository repository = new CachedPlayerProfileProxy();

            logger.Log("Первый запрос профиля 'Player_1' (ожидание 2 сек)...");
            Console.WriteLine(repository.GetProfileData("Player_1")); 

            logger.Log("\nВторой запрос профиля 'Player_1' (мгновенно)...");
            Console.WriteLine(repository.GetProfileData("Player_1")); 

            logger.Log("\nПервый запрос профиля 'Player_2' (ожидание 2 сек)...");
            Console.WriteLine(repository.GetProfileData("Player_2")); 

            logger.Log("\n=== ДЕМОНСТРАЦИЯ ЗАВЕРШЕНА ===");
        }
    }
