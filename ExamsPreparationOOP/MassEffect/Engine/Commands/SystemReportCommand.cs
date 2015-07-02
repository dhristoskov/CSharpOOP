using System;
using System.Collections;
using System.Linq;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var intactShips = 
                GameEngine.Starships.Where(s => s.Health > 0 && s.Location.Name == commandArgs[1]).OrderByDescending(s => s.Health).ThenByDescending(s => s.Shields).ToArray();
            var destroyed = GameEngine.Starships.Where(s => s.Health == 0 && s.Location.Name == commandArgs[1]).OrderBy(s => s.Name).ToArray();

            Console.WriteLine("Intact ships:");
            if (intactShips.Length > 0)
            {
                foreach (var intactShip in intactShips)
                {
                    Console.WriteLine(intactShip.ToString());
                } 
            }
            else
            {
                Console.WriteLine("N/A");
            }

            Console.WriteLine("Destroyed ships:");
            if (destroyed.Length > 0)
            {
                foreach (var destShip in destroyed)
                {
                    Console.WriteLine(destShip.ToString());
                }
            }
            else
            {
                Console.WriteLine("N/A");
            }
        }
    }
}
