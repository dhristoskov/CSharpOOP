using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.GameEngine
{
    class EngineUpdate : Engine
    {
        protected override void CreateCharacter(string[] inputParams)
        {
            int x = 0, y = 0;
            Team team = 0;
            string name = inputParams[2];
            if (!int.TryParse(inputParams[3], out x) && int.TryParse(inputParams[4], out y))
            {
                Console.WriteLine("Invalid coordinates");
            }
            switch (inputParams[5])
            {
                case "Red":
                    team = Team.Red;
                    break;
                case "Blue":
                    team = Team.Blue;
                    break;
            }

            switch (inputParams[1])
            {
                case "mage":
                    characterList.Add(new Mage(name, x, y, team));
                    break;
                case "warrior":
                    characterList.Add(new Warrior(name, x, y, team));
                    break;
                case "healer":
                    characterList.Add(new Healer(name, x, y, team));
                    break;
            }
        }

        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    PrintCharactersStatus(characterList);
                    break;
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            var character = GetCharacterById(inputParams[1]);

            string name = inputParams[3];
            switch (inputParams[2])
            {
                case "axe":
                    character.AddToInventory(new Axe(name));
                    break;
                case "shield":
                    character.AddToInventory(new Shield(name));
                    break;
                case "pill":
                    character.AddToInventory(new Pill(name));
                    break;
                case "injection":
                    character.AddToInventory(new Injection(name));
                    break;
            }
        }
    }
}
