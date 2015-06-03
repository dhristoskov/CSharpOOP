using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop_2
{
    class Battery
    {
        private string type;
        private string lifeTime;

        public Battery(string type, string lifeTime)
        {
            this.Type = type;
            this.LifeTime = lifeTime;
        }
        public string Type
        {
            get { return this.type; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter battery type!");
                }
                else
                {
                    this.type = value;
                }
            }
        }
        public string LifeTime
        {
            get { return this.lifeTime; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter battery type!");
                }
                else
                {
                    this.lifeTime = value;
                }
            }
        }
    }
}
