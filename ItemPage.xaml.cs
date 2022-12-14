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
		GetItems(_id);
        GetTotalCost(_id);
	}

    private void GetTotalCost(int Id)
    {
        double res = App.ItemRepo.GetTotalCost(Id);
        lblCost.Text += res;
    }

    private void GetItems(int Id)
    {
        List<Item> item = App.ItemRepo.GetAllItem(Id);
        listItem.ItemsSource = item;
    }

    private void BtnAdd_Clicked(object sender, EventArgs e)
    {
        App.ItemRepo.AddNewItem(EntName.Text, Convert.ToDouble(EntPrice.Text), _id);
        GetItems(_id);
        EntName.Text = "";
        EntPrice.Text = "";
    }

    private void rbSelect_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var check = e.Value;
        App.ItemRepo.CheckItem(check);
        GetTotalCost(_id);
    }
}