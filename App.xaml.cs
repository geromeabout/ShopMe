using ShopMe.Data;

namespace ShopMe;

public partial class App : Application
{
    public static ListRepository ListRepo { get; private set; }
    public static ItemRepository ItemRepo { get; private set; }
    public App(ListRepository listRepo, ItemRepository itemRepo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		ListRepo = listRepo;
		ItemRepo = itemRepo;
	}
}
