using SQLite;
using ShopMe.Models;
using System.Diagnostics;
using System.Xml.Linq;

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
    public void AddNewItem(Item item)
    {
        int result = 0;
        try
        {
            // TODO: Call Init()
            Init();

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(item.Name))
                throw new Exception("Valid name required");

            // TODO: Insert the new person into the database
            //result = 0;
            result = conn.Insert(new Item { Name = item.Name, Price = item.Price, ListId = item.ListId });

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, item.Name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", item.Name, ex.Message);
        }

    }
    public void CheckItem(Item item) 
    {
        int result = 0;
        try
        {
            Init();
            result = conn.Update(new Item { IsDone = item.IsDone, ListId = item.ListId });

        }
        catch (Exception ex)
        {

            StatusMessage = string.Format("Something went wrong. {0}", ex.Message); ;
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
    public double GetTotalCost(int Id)
    {
        double result = 0.0;
        try
        {
            Init();
            result = conn.Table<Item>().Where(c => c.ListId == Id && c.IsDone == true).Sum(c => c.Price);
            
        }
        catch (Exception ex)
        {

            StatusMessage = string.Format("Something went wrong. {0}", ex.Message);
        }
        return result;
    }
}
