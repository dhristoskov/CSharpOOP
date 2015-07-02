using System;
using System.Linq;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            IStarship attacking = GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[1]);
            IStarship target = GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[2]);
            if (attacking == null || target == null)
            {
                throw new ShipException("Attacking or target ship does not exist");
            }

            if (attacking.Location.Name != target.Location.Name)
            {
                throw new LocationOutOfRangeException(Messages.NoSuchShipInStarSystem);
            }
            target.RespondToAttack(attacking.ProduceAttack());
            Console.WriteLine(Messages.ShipAttacked,attacking.Name,target.Name);
            if (target.Health <= 0)
            {
                Console.WriteLine(Messages.ShipDestroyed,target.Name);
            }
        }
    }
}
