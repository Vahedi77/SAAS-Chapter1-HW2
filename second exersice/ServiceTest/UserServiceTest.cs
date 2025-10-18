using second_exersice;
using Service;

namespace ServiceTest;
using Xunit;
using Assert = Xunit.Assert;
public class UserServiceTest
{
    [Fact]
    public void AddItemIsAdmin()
    {
        Random random = new Random();
        ItemService service = new ItemService();
        User admin = new User ("admin","1234","notvalid@gmail.com", true);
        Item item = new Book (random.Next(), "Test Book", 100, "Author", 200 );

        Boolean result= service.AddItem(item, admin);
        Assert.True(result);
    }
    [Fact]
    public void AddItemIsNotAdmin()
    {
        Random random = new Random();
        ItemService service = new ItemService();
        User admin = new User ("normal user","1234","notvalid@gmail.com",false);
        Item item = new Book (random.Next(), "Test Book", 100, "Author", 200 );

        Boolean result= service.AddItem(item, admin);
        Assert.False(result);
    }
    [Fact]
    public void RemoveItemIsAdmin()
    {
        Random random = new Random();
        ItemService service = new ItemService();
        User admin = new User (  "admin","1234","notemail", true);
        Item item = new Clothes( random.Next(), "Test Book", 100, 2);

        service.AddItem(item, admin);
        Boolean result = service.RemoveItem(item.ItemId, admin);

        Assert.True(result);
        Assert.DoesNotContain(item, service.GetAllItems());
    }
    [Fact]
    public void RemoveItemIsNotAdmin()
    {
        Random random = new Random();
        ItemService service = new ItemService();
        User admin1 = new User (  "admin","1234","notemail", true);

        User admin = new User (  "normalUser","1234","notemail",false);
        Item item = new Clothes( random.Next(), "Test Book", 100, 2);

        service.AddItem(item, admin1);
        Boolean result = service.RemoveItem(item.ItemId, admin);

        Assert.False(result);
        Assert.Contains(item, service.GetAllItems());
    }
    [Fact]
    public void PurchaseItemExists()
    {
        ItemService service = new ItemService();
        Random random = new Random();
        User admin = new User ("admin","1234","notemail", true);
        User buyer = new User ("normalUser","1234","notemail",false);
        Item item = new Book (random.Next() , "Test Book", 100, "Author", 200);

        service.AddItem(item, admin);
        Boolean result = service.PurchaseItem(item.ItemId, buyer);

        Assert.True(result);
    }
    [Fact]
    public void PurchaseItemDoesNotExists()
    {
        ItemService service = new ItemService();
        Random random = new Random();
        User admin = new User ("admin","1234","notemail", true);
        User buyer = new User ("normalUser","1234","notemail",false);
        Item item = new Book (random.Next() , "Test Book", 100, "Author", 200);

        service.AddItem(item, admin);
        Boolean result = service.PurchaseItem(random.Next(), buyer);
        Assert.False(result);
    }
    
}