
namespace ShopMe;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		GetList();
	}

    private void GetList()
    {
        List<Models.List> list = App.ListRepo.GetAllList();
        listList.ItemsSource = list;
    }

    private void BtnAdd_Clicked(object sender, EventArgs e)
    {
        App.ListRepo.AddNewList(EntName.Text);
        GetList();
        EntName.Text= "";
    }

    private void listList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var currentSelection = e.SelectedItem as Models.List;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new ItemPage(currentSelection.Id, currentSelection.Name));
        ((ListView)sender).SelectedItem = null;
    }
}

