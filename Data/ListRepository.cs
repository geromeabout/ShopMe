using SQLite;
using ShopMe.Models;

namespace ShopMe.Data;

public class ListRepository
{
    string _dbPath;
    public string StatusMessage { get;set; }

    private SQLiteConnection conn;

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Models.List>();
    }
    public ListRepository(string dbPath)
    {
        _dbPath = dbPath;
    }
    public void AddNewList(string name)
    {
        int result = 0;
        try
        {
            Init();
            if (string.IsNullOrEmpty(name)) throw new Exception("Valid name required.");
            result = conn.Insert(new Models.List { Name = name });

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {

            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }
    }
    public List<Models.List> GetAllList()
    {
        try
        {
            Init();
            return conn.Table<Models.List>().ToList();

        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Models.List>();
    }
}
