namespace Marketplace.Domain;

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
    
    public ICollection<User> Users { get; set; } = new List<User>();
}