namespace ShoppingHelper.Models;

public class Shopping
{
    public DateTime Date { get; set; } = DateTime.Now;

    public List<ShoppingItem> Items { get; set; } = new();
}
