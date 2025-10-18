namespace TestProject1.Models;

public class Clothes : Item
{
    public Clothes(int itemId, string name, decimal price, int size) : base(itemId, name, price)
    {
        this.size = size;
    }

    public int size { get; set; }
}
