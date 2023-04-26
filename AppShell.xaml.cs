namespace Drink_Book_Data_Entry_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.EntryView), typeof(Views.EntryView));
        Routing.RegisterRoute(nameof(Views.DrinksView), typeof(Views.DrinksView));
    }
}
