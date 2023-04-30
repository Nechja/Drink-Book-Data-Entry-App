using CommunityToolkit.Mvvm.ComponentModel;
using Drink_Book_Data_Entry_App.ViewModels;
using System.Collections.ObjectModel;

namespace Drink_Book_Data_Entry_App.Views;

public partial class EntryView : ContentPage
{
    DataEntryViewModel vm;
    public EntryView(DataEntryViewModel modelView)
	{
        vm = modelView;
        InitializeComponent();
		BindingContext = vm;
        Application.Current.UserAppTheme = AppTheme.Dark;
        ingCollection.ItemsSource = vm.ingredients;
    }

    public EntryView(DataEntryViewModel modelView, Models.Drink drink)
    {
        vm = modelView;
        InitializeComponent();
        BindingContext = vm;
        ObservableCollection<Models.Ingredient> ingredientsLoad = new ObservableCollection<Models.Ingredient>();
        foreach(Models.Ingredient ingredient in drink.Ingredients)
        {
            ingredientsLoad.Add(ingredient);
        }
        vm.ingredients = ingredientsLoad;
        ingCollection.ItemsSource = vm.ingredients;
    }

    private void Ing_Clicked(object sender, EventArgs e)
    {
        foreach(Object o in IngredientEntryStack.Children)
        {
            if(o is Entry)
            {
                Entry entry = (Entry)o;
                entry.Text = "";
            }
        }
    }

    private async void Remove_Clicked(object sender, EventArgs e)
    {

        if(sender is Button)
        {
            Button btn = sender as Button;
            if(btn.CommandParameter is Models.Ingredient)
            {
                Models.Ingredient ingredient = btn.CommandParameter as Models.Ingredient;
                vm.ingredients.Remove(ingredient);
            }

        }
        
    }

    private async void Clear_Clicked(object sender, EventArgs e)
    {
        foreach (Object o in AllGrid.Children)
        {
            if (o is Entry)
            {
                Entry entry = (Entry)o;
                entry.Text = string.Empty;
            }
            if(o is Editor)
            {
                Editor editor = (Editor)o;
                editor.Text = string.Empty;
            }
        }

        vm.ingredients.Clear();
    }

    private async void errorpass_TextChanged(object sender, TextChangedEventArgs e)
    {
        await DisplayAlert("Alert", errorpass.Text, "Okay!");
    }
}