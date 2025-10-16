using DefaultNamespace;



namespace DefaultNamespace;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== ДЕМОНСТРАЦИЯ ПОРОЖДАЮЩИХ ПАТТЕРНОВ ===\n");

            
            Console.WriteLine("--- 1. SINGLETON (Одиночка) ---");
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;
            Console.WriteLine($"logger1 == logger2: {ReferenceEquals(logger1, logger2)}");
            Console.WriteLine("Оба объекта ссылаются на один экземпляр!\n");

            
            Console.WriteLine("--- 2. BUILDER ---");
            Character warrior = new Character.Builder()
                .SetName("Конан")
                .SetClass("Воин")
                .SetHealth(100)
                .SetDamage(20)
                .Build();
            Console.WriteLine(warrior);
            Console.WriteLine();

            
            Console.WriteLine("--- 3. FACTORY METHOD---");
            Location forest = new Forest();
            Location cave = new Cave();
            
            forest.Enter();
            cave.Enter();
            Console.WriteLine("Разные локации создают разных врагов!\n");

            
            Console.WriteLine("--- 4. ABSTRACT FACTORY---");
            
            
            IEquipmentFactory warriorFactory = new WarriorEquipmentFactory();
            IWeapon warriorWeapon = warriorFactory.CreateWeapon();
            IArmor warriorArmor = warriorFactory.CreateArmor();
            Logger.Instance.Log($"[Abstract Factory] Экипировка воина: {warriorWeapon.Name} (урон: {warriorWeapon.Damage}), {warriorArmor.Name} (защита: {warriorArmor.Defense})");

            
            IEquipmentFactory mageFactory = new MageEquipmentFactory();
            IWeapon mageWeapon = mageFactory.CreateWeapon();
            IArmor mageArmor = mageFactory.CreateArmor();
            Logger.Instance.Log($"[Abstract Factory] Экипировка мага: {mageWeapon.Name} (урон: {mageWeapon.Damage}), {mageArmor.Name} (защита: {mageArmor.Defense})");

            Console.WriteLine("\nКаждая фабрика создает согласованное семейство объектов!");
        }
    }

    