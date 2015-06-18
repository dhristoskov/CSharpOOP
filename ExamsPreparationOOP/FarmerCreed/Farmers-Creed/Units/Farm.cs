using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Interfaces;

    public class Farm : GameObject, IFarm
    {
        private readonly List<Plant> _plants= new List<Plant>();
        private readonly List<Animal> _animals= new List<Animal>();
        private readonly List<Product> _products= new List<Product>();  

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
            this._products.Add(product);
        }

        public void AddPlant(Plant plant)
        {
            this._plants.Add(plant);
        }

        public void AddAnimal(Animal animal)
        {
            this._animals.Add(animal);
        }

        public void Exploit(IProductProduceable productProducer)
        {
            var product = productProducer.GetProduct();
            bool isInList = false;
            foreach (var t in this.Products)
            {
                if (t.Id == product.Id)
                {
                    t.Quantity += product.Quantity;
                    isInList = true;
                }
            }
            if (!isInList)
            {
                AddProduct(product);
            }
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct,productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            this.Animals.ForEach(x => x.Starve());
            var growingPlants = this.Plants.Where(x => x.HasGrown == false).ToList();
            var grownPlants = this.Plants.Where(x => x.HasGrown == true).ToList();
            growingPlants.ForEach(x=>x.Grow());
            grownPlants.ForEach(x=>x.Wither());
        }

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder(base.ToString());
            sb.AppendLine();
            foreach (var animal in this.Animals.Where(a=>a.IsAlive==true).OrderBy(a=>a.Id))
            {
                sb.AppendLine(animal.ToString());
            }
            foreach (var plant in this.Plants.Where(p=>p.IsAlive==true).OrderBy(p=>p.Health).ThenBy(p=>p.Id))
            {
                sb.AppendLine(plant.ToString());
            }
            foreach (var product in this.Products.OrderBy(p=>p.ProductType.ToString()).ThenByDescending(p=>p.Quantity).ThenBy(p=>p.Id))
            {
                sb.AppendLine(product.ToString());
            }
            return sb.ToString();
        }
    }
}
