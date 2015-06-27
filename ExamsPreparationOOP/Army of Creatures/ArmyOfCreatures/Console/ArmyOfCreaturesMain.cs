using ArmyOfCreatures.Extended;

namespace ArmyOfCreatures.Console
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Commands;
    using Logic;
    using Logic.Battles;

    public static class ArmyOfCreaturesMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            ICreaturesFactory creaturesFactory = GetCreaturesFactory();
            ILogger logger = new ConsoleLogger();
            IBattleManager battleManager = GetBattleManager(creaturesFactory, logger);
            
            ICommandManager commandManager = new CommandManager();

            while (true)
            {
                var commandLine = Console.ReadLine();
                commandManager.ProcessCommand(commandLine, battleManager);
            }
        }

        private static IBattleManager GetBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
        {
            return new NewBattleManager(creaturesFactory, logger);
        }

        private static ICreaturesFactory GetCreaturesFactory()
        {
            return new NewCreaturesFactory();
        }
    }
}
