namespace TestProject1.Models;

public class Book : Item
{
    public Book(int itemId, string name, decimal price, string author, int pages) : base(itemId, name, price)
    {
        Author = author;
        Pages = pages;
    }

    public string Author { get; set; }
    public int Pages { get; set; }
}