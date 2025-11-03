namespace Marketplace.Domain;

public class User
{
    public int Id;
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
    public User(string username, string password, string email, bool isAdmin)
    {
        Id++;
        Username = username;
        Password = password;
        Email = email;
        IsAdmin = isAdmin;
    }

    public int getId()
    {
        return Id;
    }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
    
    public ICollection<Item> Items { get; set; } = new List<Item>();
}
