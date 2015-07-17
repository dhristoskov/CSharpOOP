using FarmersCreed.Simulator;

namespace FarmersCreed.Units
{
    public class ExtendedFarmSimulator : FarmSimulator
    {
        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                {
                    CherryTree cherryTree = new CherryTree(id);
                    ((Farm) this.farm).AddPlant(cherryTree);
                }
                    break;
                case "TobaccoPlant":
                {
                    TobaccoPlant tobaccoPlant = new TobaccoPlant(id);
                    ((Farm) this.farm).AddPlant(tobaccoPlant);
                }
                    break;
                case "Cow":
                {
                    Cow cow = new Cow(id);
                    ((Farm) this.farm).AddAnimal(cow);
                }
                    break;
                case "Swine":
                {
                    Swine swine = new Swine(id);
                    ((Farm) this.farm).AddAnimal(swine);
                }
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }

        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "feed":
                {
                    Animal animal = GetAnimalById(inputCommands[1]);
                    Food food = (Food)GetProductById(inputCommands[2]);
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
                    if (inputCommands[1] == "animal")
                    {
                        Animal animal = GetAnimalById(inputCommands[2]);
                        this.farm.Exploit(animal);
                    }
                    else
                    {
                        Plant plant = GetPlantById(inputCommands[2]);
                        this.farm.Exploit(plant);
                    }
                }
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }
        }
    }
}