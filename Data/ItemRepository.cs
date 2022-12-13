

using ShopMe.Models;

namespace ShopMe.Data;

public class ItemRepository
{
    string _dbPath;
    public string StatusMessage { get; set; }

    // TODO: Add variable for the SQLite connection

    private void Init()
    {
        // TODO: Add code to initialize the repository         
    }

    public ItemRepository(string dbPath)
    {
        _dbPath = dbPath;
    }
    public void AddNewItem(string name, double price)
    {
        int result = 0;
        try
        {
            // TODO: Call Init()

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            // TODO: Insert the new person into the database
            result = 0;

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }

    }
    public List<Item> GetAllItem()
    {
        // TODO: Init then retrieve a list of Person objects from the database into a list
        try
        {

        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Item>();
    }
}
