using second_exersice;
using Service;

public class UserInterface
{ 
    static UserService userService = new UserService();
    static ItemService itemService = new ItemService();
    static User currentUser = null;
    
    public static void Main()
    {
        User admin = new User("admin", "1234", "normal@gmail.com", true);
        userService.Register(admin);
        {
            Console.Clear();
            Console.WriteLine("SHOPPING");
            Console.WriteLine("1.rejister");
            Console.WriteLine("2.login");
            Console.WriteLine("3.exit");
            string choice = Console.ReadLine();
            switch (choice)
            { 
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Unvalid choice.");
                    break;
            }

            if (currentUser != null)
                ShowMainMenu();
            else
            {
                Console.WriteLine("exeption");
            }
        }
    }

    static void Register()
    {
        Console.Write("username: ");
        string username = Console.ReadLine();
        Console.Write("password: ");
        string password = Console.ReadLine();
        Console.Write("email: ");
        string email = Console.ReadLine();
        User user = new User(username, password, email,false);
        Boolean result = userService.Register(user);
        currentUser = user;
        Console.WriteLine(result ? "successfully" : "before registered");
    } 
    static void Login()
    {
        Console.Write("username:");
        string username = Console.ReadLine();
        Console.Write("password : ");
        string password = Console.ReadLine();

        User user = userService.Login(username, password);
        if (user != null)
        {
            currentUser = user;
            Console.WriteLine(" successfully.");
        }
        else
        {
            Console.WriteLine("the information is incorrect.");
        }
        Console.ReadKey();
    }

    static void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1.all items");
            Console.WriteLine("2.buy items");
            if (currentUser.IsAdmin)
            {
                Console.WriteLine("3.add item");
                Console.WriteLine("4.remove item");
            }
            Console.WriteLine("0.exit");
            String choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowItems();
                    break;
                case "2":
                    PurchaseItem();
                    break;
                case "3":
                    if (currentUser.IsAdmin) AddItem();
                    else Console.WriteLine("You do not have this permission.");
                    break;
                case "4":
                    if (currentUser.IsAdmin) RemoveItem();
                    else Console.WriteLine("You do not have this permission.");
                    break;
                case "0":
                    currentUser = null;
                    return;
                default:
                    Console.WriteLine("unvalid choice.");
                    break;
            }
            Console.ReadKey();
        }
    }

    static void ShowItems()
    {
        var items = itemService.GetAllItems();
        Console.WriteLine("ALL ITEMS:");
        foreach (var item in items)
        {
            Console.WriteLine(item.ItemId + item.Name + item.Price);
        }
    }

    static void PurchaseItem()
    {
        Console.Write("please enter item ID: ");
        String idStr = Console.ReadLine();
        Boolean result = itemService.PurchaseItem(int.Parse(idStr), currentUser); 
        Console.WriteLine(result ? "  successful." : "item didnt found.");
    }

    static void AddItem()
    {
        Random random = new Random();
        Console.Write("name: ");
        var name = Console.ReadLine();
        Console.Write("price: ");
        String priceStr = Console.ReadLine();
        Console.Write("book or clothes? b,book / c,clothes ");
        var bookOrClothesStr = Console.ReadLine();
        if (bookOrClothesStr == "b")
        {
            var item = new Book(random.Next(), name,int.Parse(priceStr), "unknown", 100);
            itemService.AddItem(item, currentUser);
            Console.WriteLine("added.");
        }
        else if (bookOrClothesStr == "c")
        {
            var item = new Clothes(random.Next(), name,int.Parse(priceStr),2);
            itemService.AddItem(item, currentUser);
            Console.WriteLine("added.");
        }
        
    }
    static void RemoveItem()
    {
        Console.Write("please enter item ID: ");
        var idStr = Console.ReadLine();
        var result = itemService.RemoveItem(int.Parse(idStr), currentUser);
        Console.WriteLine(result ? "removed." : "unvalid id.");
        
    }
}