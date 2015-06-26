using System.Collections.Generic;
using System.Linq;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class ShoppingCart : Contracts.IShoppingCart
    {
        public IList<IProduct> shopingCart { get; private set; }

        public ShoppingCart()
        {
            this.shopingCart = new List<IProduct>();
        }
         
        public void AddProduct(IProduct product)
        {
            shopingCart.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            shopingCart.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
              return  shopingCart.Any( p =>p.Name == product.Name 
                                      && p.Brand == product.Brand 
                                      && p.Price == product.Price
                                      && p.Gender == product.Gender);
        }

        public decimal TotalPrice()
        {
            return shopingCart.Sum(p => p.Price);
        }
    }
}