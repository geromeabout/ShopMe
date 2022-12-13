using ShopMe.Models;

namespace ShopMe;

public partial class ItemPage : ContentPage
{
	private int _id;
	private string _name;
	public ItemPage(int Id, string Name)
	{
		InitializeComponent();
		_id = Id;
		_name = Name;
		mainLbl.Text = _name;
		GetItems();
	}

    private void GetItems()
    {
        List<Item> item = App.ItemRepo.GetAllItem();
        listItem.ItemsSource = item;
    }

    private void BtnAdd_Clicked(object sender, EventArgs e)
    {
        App.ItemRepo.AddNewItem(EntName.Text, Convert.ToDouble(EntPrice.Text));
        GetItems();
        EntName.Text = "";
        EntPrice.Text = "";
    }
}