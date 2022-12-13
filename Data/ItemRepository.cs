using SQLite;
using ShopMe.Models;

namespace ShopMe.Data;

public class ItemRepository
{
    string _dbPath;
    public string StatusMessage { get; set; }

    // TODO: Add variable for the SQLite connection
    private SQLiteConnection conn;

    private void Init()
    {
        // TODO: Add code to initialize the repository
        if (conn != null)
        return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Item>();
    }

    public ItemRepository(string dbPath)
    {
        _dbPath = dbPath;
    }
    public void AddNewItem(string name, double price, int id)
    {
        int result = 0;
        try
        {
            // TODO: Call Init()
            Init();

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            // TODO: Insert the new person into the database
            //result = 0;
            result = conn.Insert(new Item { Name = name, Price = price, ListId = id });

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }

    }
    public List<Item> GetAllItem(int id)
    {
        // TODO: Init then retrieve a list of Person objects from the database into a list
        try
        {
            Init();
            return conn.Table<Item>().Where(c => c.ListId == id).ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Item>();
    }
}
