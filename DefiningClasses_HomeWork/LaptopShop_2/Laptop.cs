using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop_2
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private string graphicsCard;
        private string hardDrive;
        private string screen;
        private decimal price;
        private string ramMemory;
        private Battery battery;
        static bool secondConstr = false;
        static bool thirdConstr = false;

        #region Constructors
        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }
        public Laptop(string model, decimal price, string manufactorer, string processor, string graphicsCard, string hardDrive,
            string screen, string ramMemory)
        {
            secondConstr = true;
            this.Model = model;
            this.Price = price;
            this.Processor = processor;
            this.GraphicsCard = graphicsCard;
            this.HardDrive = hardDrive;
            this.Screen = screen;
            this.Manufacturer = manufactorer;
            this.RamMemory = ramMemory;
        }
        public Laptop(string model, decimal price, string manufactorer, string processor, string graphicsCard, string hardDrive,
            string screen, string ramMemory,string type,string lifeTime)
        {
            thirdConstr = true;
            secondConstr = false;
            this.Model = model;
            this.Manufacturer = manufactorer;
            this.Price = price;
            this.Processor = processor;
            this.GraphicsCard = graphicsCard;
            this.HardDrive = hardDrive;
            this.Screen = screen;           
            this.RamMemory = ramMemory;
            this.battery = new Battery(type, lifeTime);
        }

        #endregion

        #region Properties
        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter laptop model!");
                }
                else
                {
                    this.model = value;
                }
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer;}
            set { this.manufacturer = value;}
        }
        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter laptop processor type!");
                }
                else
                {
                    this.processor = value;
                }
            }
        }
        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter laptop Graphics Card type!");
                }
                else
                {
                    this.graphicsCard = value;
                }
            }
        }
        public string HardDrive
        {
            get { return this.hardDrive; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter laptop Hard Drive!");
                }
                else
                {
                    this.hardDrive = value;
                }
            }
        }
        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter laptop Hard Drive!");
                }
                else
                {
                    this.screen = value;
                }
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Please enter correct laptop price!");
                }
                else
                {
                    this.price = value;
                }
            }
        }
        public string RamMemory
        {
            get { return this.ramMemory; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter laptop RAM memory!");
                }
                else
                {
                    this.ramMemory = value;
                }
            }
        }
        #endregion

        public override string ToString()
        {
            if (secondConstr)
            {
                return String.Format("Model: {0}, Manufactorer: {1}, Processor: {2},Graphics Card: {3},Hard Drive: {4},Monitor: {5},RAM: {6}, Price: {7:f2} lv.",
                    this.Model, this.manufacturer, this.Processor, this.GraphicsCard, this.HardDrive, this.Screen, this.RamMemory, this.Price);
            }
            else if(thirdConstr)
            {
                return String.Format("Model: {0}, Manufactorer: {1}, Processor: {2},Graphics Card: {3},Hard Drive: {4},Monitor: {5},RAM: {6},Battery Type: {7},Battery LifeTime {8}, Price: {9:f2} lv.",
                    this.Model, this.manufacturer, this.Processor, this.GraphicsCard, this.HardDrive, this.Screen, this.RamMemory,this.battery.Type,this.battery.LifeTime, this.Price);
            }
            else
            {
                return String.Format("Model: {0}, Price: {1:f2} lv.", this.Model, this.Price);
            }         
        }
    }
}
