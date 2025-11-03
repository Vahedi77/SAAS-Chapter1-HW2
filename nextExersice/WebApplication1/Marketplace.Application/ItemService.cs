using Marketplace.Application.Interfaces;
using Marketplace.Domain;

namespace Marketplace.Application;

public class ItemService : IItemService
{
    private List<Item> items = new();

    public bool AddItem(Item item, User user)
    {
        if (user.IsAdmin)
        {
            items.Add(item);
            return true;
        }
        return false;
    }
    public bool RemoveItem(int itemId, User user)
    {
        if (!user.IsAdmin) return false;
        foreach (var item in items)
        {
            if (item.ItemId == itemId)
            {
                items.Remove(item);
                return true;
            }
        }
        return false;
    }
    public bool PurchaseItem(int itemId, User user)
    {
        foreach (var item in items)
        {
            if (item.ItemId == itemId)
            {
                Console.WriteLine("{"+user.Username+"} purchased {"+item.Name+"}");
                return true;
            }
        }
        return false;
    }

    public List<Item> GetAllItems()
    {
        return items;
    }
}