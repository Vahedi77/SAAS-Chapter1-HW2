namespace second_exersice;

public class Item
{
    public Item(int itemId, string name, decimal price)
    {
        ItemId = itemId;
        Name = name;
        Price = price;
    }

    public int ItemId { get; set; } 
    public string Name { get; set; }
    public decimal Price { get; set; }
}