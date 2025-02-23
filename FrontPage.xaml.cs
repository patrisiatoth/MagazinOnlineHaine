namespace MagazinOnlineHaine;

public partial class FrontPage : ContentPage
{
	public FrontPage()
	{
		InitializeComponent();
	}

    private async void OnSeeCategoriesClicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new CategoryPage());
    }

}