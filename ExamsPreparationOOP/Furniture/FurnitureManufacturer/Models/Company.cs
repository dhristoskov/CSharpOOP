using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string _name;
        private string _regNumber;
        private readonly List<IFurniture> _furnitures;

        public Company(string name, string regNumber)
        {
            this.Name = name;
            this.RegistrationNumber = regNumber;
            this._furnitures = new List<IFurniture>();
        }

        #region Properties

        public string Name
        {
            get { return this._name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentNullException();
                }
                this._name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this._regNumber; }
            set
            {
                Regex rgx = new Regex(@"^\d{10}$");
                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._regNumber = value;
            }
        }

        #endregion

        #region Methods

        public ICollection<IFurniture> Furnitures => this._furnitures;

        public void Add(IFurniture furniture)
        {
            this._furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (_furnitures.Any(
                x => x.Model == furniture.Model
                     && x.Price == furniture.Price
                     && x.Material == furniture.Material
                     && x.Height == furniture.Height
                ))
            {
                _furnitures.Remove(furniture);
            }
        }

        public IFurniture Find(string model)
        {
            var product = _furnitures.FirstOrDefault(prod => prod.Model.ToLower() == model.ToLower());
            return product;
        }

        public string Catalog()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            sb.AppendLine();
            foreach (var furniture in this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model))
            {
                sb.AppendLine(furniture.ToString());
            }
            return sb.ToString();
        }

        #endregion
    }
}
