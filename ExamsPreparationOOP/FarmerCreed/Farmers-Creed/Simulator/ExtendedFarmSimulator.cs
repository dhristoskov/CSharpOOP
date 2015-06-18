using System;
using System.Runtime.Versioning;
using FarmersCreed.Interfaces;
using FarmersCreed.Units;

namespace FarmersCreed.Simulator
{
    public class ExtendedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "add":
                {
                    this.AddObjectToFarm(inputCommands);
                }
                    break;
                case "feed":
                {
                    Animal animal = GetAnimalById(inputCommands[1]);
                    Food food = (Food) GetProductById(inputCommands[2]);
                    int quantity = int.Parse(inputCommands[3]);
                    this.farm.Feed(animal, food, quantity);
                }
                    break;
                case "water":
                {
                    Plant plant = GetPlantById(inputCommands[1]);
                    this.farm.Water(plant);
                }
                    break;
                case "exploit":
                {
                    var farmUnit = GetFarmUnitById(inputCommands[1], inputCommands[2]);
                    this.farm.Exploit(farmUnit);
                }
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                {
                    var cherryTree = new CherryTree(id);
                    ((Farm) this.farm).AddPlant(cherryTree);
                }
                    break;
                case "TobaccoPlant":
                {
                    var tobaccoPlant = new TobaccoPlant(id);
                    ((Farm) this.farm).AddPlant(tobaccoPlant);
                }
                    break;
                case "Cow":
                {
                    var cow = new Cow(id);
                    ((Farm) this.farm).AddAnimal(cow);
                }
                    break;
                case "Swine":
                    {
                        var swine = new Swine(id);
                        ((Farm)this.farm).AddAnimal(swine);
                    }
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }

        private IProductProduceable GetFarmUnitById(string unitType, string unitId)
        {
            switch (unitType)
            {
                case "animal":
                    return GetAnimalById(unitId);
                case "plant":
                    return GetPlantById(unitId);
                default:throw  new ArgumentException();
            }
        }
    }
}