using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    internal class Furniture : IFurniture
    {
        private string _model;
        private string _material;
        private readonly MaterialType _materialEnum;
        private decimal _price;
        private decimal _height;

        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this._materialEnum = materialType;
            this.Price = price;
            this.Height = height;
        }

        #region Properties

        public string Model
        {
            get { return this._model; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentNullException();
                }
                this._model = value;
            }
        }

        public string Material
        {
            get { return this._materialEnum.ToString(); }
            set { this._material = value; }
        }

        public decimal Price
        {
            get { return this._price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._price = value;
            }
        }

        public decimal Height
        {
            get { return this._height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._height = value;
            }
        }

        #endregion
    }
}
