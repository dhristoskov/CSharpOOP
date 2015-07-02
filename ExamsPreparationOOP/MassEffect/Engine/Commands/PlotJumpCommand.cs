using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Locations;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
            
        }

        public override void Execute(string[] commandArgs)
        {
            IStarship ship = GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[1]);
            string currentSystemName = ship.Location.Name;
            StarSystem destinationsystem = GameEngine.Galaxy.GetStarSystemByName(commandArgs[2]);
            if (ship == null)
            {
                throw new ShipException(string.Format("Ship with name {0} does not exist", commandArgs[1]));
            }
            if (ship.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
            if (ship.Location.Name == destinationsystem.Name)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationsystem.Name));
            }

            try
            {
                GameEngine.Galaxy.TravelTo(ship, destinationsystem);
            }
            catch (Exception e)
            {
                throw e;
            }
            Console.WriteLine(Messages.ShipTraveled, ship.Name, currentSystemName, destinationsystem.Name);

        }
    }
}
