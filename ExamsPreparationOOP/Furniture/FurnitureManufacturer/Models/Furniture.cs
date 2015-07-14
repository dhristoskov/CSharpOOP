using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private string _model;
        private string _material;
        private decimal _price;
        private decimal _height;
        private readonly MaterialType _type;

        protected Furniture(string model, MaterialType type, decimal price, decimal height)
        {
            this.Model = model;
            this._type = type;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get { return this._model; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentNullException("Model", "Model name can not be null,empty or less than 3 symbols!");
                }
                this._model = value;
            }
        }

        public string Material
        {
            get { return this._type.ToString(); }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                   throw new ArgumentNullException("Material","Material can not be null or white space!");
                }
                this._material = value;
            }
        }

        public decimal Price
        {
            get { return this._price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price", "Price can not be zero or negative number!");
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
                    throw new ArgumentOutOfRangeException("Height", "Height can not be zero or negative number!");
                }
                this._height = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name,
                this.Model, this.Material, this.Price, this.Height);
        }
    }
}