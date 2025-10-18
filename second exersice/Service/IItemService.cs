using second_exersice;

namespace Service;

public interface IItemService
{ 
    public bool AddItem(Item item, User user);
    public bool RemoveItem(int itemId, User user);
    public bool PurchaseItem(int itemId, User user);
    public List<Item> GetAllItems();
}