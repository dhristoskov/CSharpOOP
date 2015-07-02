using System;
using System.Linq;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            IStarship ship = GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[1]);
            if (ship == null)
            {
                throw new ShipException("Ship not found.");
            }

            Console.WriteLine(ship.ToString());
        }
    }
}
