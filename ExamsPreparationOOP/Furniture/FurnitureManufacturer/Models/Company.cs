using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string _name;
        private string _registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentNullException("Name", "Name can not be null, empty or less than 5 symbols!");
                }
                this._name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this._registrationNumber; }
            private set
            {
                Regex rgx = new Regex(@"^\d{10}$");
                if (!rgx.IsMatch(value)||String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Registration Number",
                        "Registration number must be 10 digits long!");
                }
                this._registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (
                this.Furnitures.Any(x => x.Model == furniture.Model
                                         && x.Price == furniture.Price
                                         && x.Height == furniture.Height
                                         && x.Material == furniture.Material))
            {             
                Furnitures.Remove(furniture);
            }
        }

        public IFurniture Find(string model)
        {
            var furnitureToBeFind = this.Furnitures.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());
            return furnitureToBeFind;
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();

            catalog.AppendFormat("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");
          
            foreach (var product in this.Furnitures.OrderBy(f=>f.Price).ThenBy(f=>f.Model))
            {
                catalog.AppendLine();
                catalog.Append(product.ToString());
            }

            return catalog.ToString();
        }
    }
}

