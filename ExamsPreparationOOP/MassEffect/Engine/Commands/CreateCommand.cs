using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            
            StarshipType type = (StarshipType)Enum.Parse(typeof (StarshipType), commandArgs[1]);
            StarSystem system = GameEngine.Galaxy.GetStarSystemByName(commandArgs[3]);
            IStarship ship = GameEngine.ShipFactory.CreateShip(type, commandArgs[2], system);

            if (commandArgs.Length > 4 )
            {
                for (int i = 4; i < commandArgs.Length; i++)
                {
                    EnhancementType enchantmentType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);
                    ship.AddEnhancement(GameEngine.EnhancementFactory.Create(enchantmentType));
                }
            }

            if (GameEngine.Starships.Any(s => s.Name == ship.Name))
            {
                throw new ShipException(Messages.DuplicateShipName);
            }
            Console.WriteLine(Messages.CreatedShip,ship.GetType().Name,ship.Name);
            GameEngine.Starships.Add(ship);
        }
    }
}
