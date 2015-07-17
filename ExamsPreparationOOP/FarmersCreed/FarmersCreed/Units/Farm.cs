using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Interfaces;

    public class Farm : GameObject, IFarm
    {
        private readonly List<Plant> _plants = new List<Plant>();
        private readonly List<Animal> _animals = new List<Animal>();
        private readonly List<Product> _products = new List<Product>();

        public Farm(string id)
            : base(id)
        {
        }

        public List<Plant> Plants
        {
            get { return this._plants; }
        }

        public List<Animal> Animals
        {
            get { return this._animals; }
        }

        public List<Product> Products
        {
            get { return this._products; }
        }

        public void AddProduct(Product product)
        {
            this.Products.Add(product);
        }

        public void AddAnimal(Animal animal)
        {
            this.Animals.Add(animal);
        }

        public void AddPlant(Plant plant)
        {
            this.Plants.Add(plant);
        }

        public void Exploit(IProductProduceable productProducer)
        {
            var newProduct = productProducer.GetProduct();
            bool isInList = false;
            foreach (var product in this.Products)
            {
                if (product.Id == newProduct.Id)
                {
                    product.Quantity += newProduct.Quantity;
                    isInList = true;
                }
            }
            if (!isInList)
            {
                AddProduct(newProduct);
            }
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            var growingPlants = this.Plants.Where(plant => plant.HasGrown == false).ToList();
            var grownPlants = this.Plants.Where(plant => plant.HasGrown).ToList();
            this.Animals.ForEach(animal => animal.Starve());
            growingPlants.ForEach(plant=>plant.Grow());
            grownPlants.ForEach(plant=>plant.Wither());           
        }

        public override string ToString()
        {
            StringBuilder farmCatalog = new StringBuilder(base.ToString());
            farmCatalog.AppendLine();

            foreach (var animal in this.Animals
                .Where(animal => animal.IsAlive)
                .OrderBy(animal => animal.Id))
            {
                farmCatalog.AppendLine(animal.ToString());
            }

            foreach (var plant in this.Plants
                .Where(plant => plant.IsAlive)
                .OrderBy(plant => plant.Health)
                .ThenBy(plant => plant.Id))
            {
                farmCatalog.AppendLine(plant.ToString());
            }

            foreach (var product in this.Products
                .OrderBy(product=>product.ProductType.ToString())
                .ThenByDescending(product=>product.Quantity)
                .ThenBy(product=>product.Id))
            {
                farmCatalog.AppendLine(product.ToString());
            }

            return farmCatalog.ToString();
        }
    }
}
