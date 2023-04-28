using System.Collections.ObjectModel;

namespace Drink_Book_Data_Entry_App.Views;

public partial class DrinksView : ContentPage
{
    private ObservableCollection<Models.Drink> drinks = new ObservableCollection<Models.Drink>();
	public DrinksView()
	{
		InitializeComponent();
        List<Models.Drink> drinksList = Services.DataStore.GetDrinks();
        foreach(Models.Drink drink in drinksList)
        {
            drinks.Add(drink);
        }
        DrinkCollectionView.ItemsSource = drinks;
	}

    private async void Remove_Clicked(object sender, EventArgs e)
    {

        if (sender is Button)
        {
            Button btn = sender as Button;
            if (btn.CommandParameter is Models.Drink)
            {
                Models.Drink drink = btn.CommandParameter as Models.Drink;
                drinks.Remove(drink);
                Services.DataStore.UpdateDrinkList(drinks.ToList<Models.Drink>());
                drinks.Clear();
                List<Models.Drink> drinksList = Services.DataStore.GetDrinks();
                foreach (Models.Drink d in drinksList)
                {
                    drinks.Add(d);
                }
            }

        }

    }
}