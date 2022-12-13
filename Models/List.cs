using SQLite;

namespace ShopMe.Models;

[Table("list")]
public class List
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [MaxLength(250), Unique]
    public string Name { get; set; }
}
