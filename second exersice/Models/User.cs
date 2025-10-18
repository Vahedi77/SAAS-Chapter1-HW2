namespace second_exersice;

public class User
{
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
    public User(string username, string password, string email, bool isAdmin)
    {
        Username = username;
        Password = password;
        Email = email;
        IsAdmin = isAdmin;
    }

    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
}