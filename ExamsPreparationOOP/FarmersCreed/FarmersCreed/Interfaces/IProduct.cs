using FarmersCreed.Units;

namespace FarmersCreed.Interfaces
{
    public interface IProduct
    {
        ProductType ProductType { get; set; }

        int Quantity { get; set; }
    }
}
