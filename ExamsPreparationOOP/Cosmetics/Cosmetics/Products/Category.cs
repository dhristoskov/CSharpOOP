using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private string _name;
        public IList<IProduct> cosmetic { get; private set; } 

        public Category(string name)
        {
            this.Name = name;
            this.cosmetic= new List<IProduct>();
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentException(String.Format("Category name must be between {0} and {1} symbols long!", 2, 15));
                }
                else if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(Name,"Category name can not be null or empty!");
                }
                this._name = value;
            }
        }
        public void AddCosmetics(IProduct cosmetics)
        {
            cosmetic.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (cosmetic.Any(p => p.Name == cosmetics.Name
               && p.Brand == cosmetics.Brand 
               && p.Price == cosmetics.Price
               && p.Gender == cosmetics.Gender))
            {
                cosmetic.Remove(cosmetics);
            }
            else
            {
                throw new ArgumentException(String.Format("Product {0} does not exist in category {1}!", cosmetics.Name,
                    this.Name));
            }        
        }

        public string Print()
        {
            StringBuilder category= new StringBuilder();
            category.AppendFormat("{0} category - {1} {2} in total", this.Name, this.cosmetic.Count,
                this.cosmetic.Count == 1 ? "product" : "products");
            foreach (IProduct product in this.cosmetic.OrderBy(s=>s.Brand).ThenByDescending(s=>s.Price))
            {
                category.AppendLine().Append(product.Print());
            }
            return category.ToString();    
        }
    }
}