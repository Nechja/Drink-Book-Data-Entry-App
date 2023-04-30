using Drink_Book_Data_Entry_App.ViewModels;

namespace Drink_Book_Data_Entry_App.Views;

public partial class MenuView : ContentPage
{
	public MenuView(MenuViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		Application.Current.UserAppTheme = AppTheme.Dark;
	}
}