using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Drink_Book_Data_Entry_App.Views;
using Microsoft.Maui.Controls;

namespace Drink_Book_Data_Entry_App.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        [RelayCommand]
        async void GoToDrinks()
        {
            await Shell.Current.GoToAsync(nameof(DrinksView));
        }
        [RelayCommand]
        async void GoToEntry()
        {
            await Shell.Current.GoToAsync(nameof(EntryView));
        }
        [RelayCommand]
        async void GotoNewEntry()
        {
            await Shell.Current.GoToAsync($"{nameof(EntryView)}?NewDrink={true}");
        }
    }
}
