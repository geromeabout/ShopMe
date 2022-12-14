using SQLite;

namespace ShopMe.Models;

[Table("item")]
public class Item
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [MaxLength(250), Unique]
    public string Name { get; set; }
    [MaxLength(10)]
    public double Price { get; set; }
    [MaxLength(1)]
    public int ListId { get; set; }
    public bool IsDone { get; set; }
}
