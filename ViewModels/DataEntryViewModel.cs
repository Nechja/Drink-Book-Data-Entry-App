
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Drink_Book_Data_Entry_App.Models;
using Drink_Book_Data_Entry_App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Drink_Book_Data_Entry_App.ViewModels
{
    public partial class DataEntryViewModel : ObservableObject
    {
        public event EventHandler IngredientClear;


        public ObservableCollection<Ingredient> ingredients { get; set; } = new ObservableCollection<Models.Ingredient>();
        public Drink Drink { get; set; }




        [ObservableProperty]
        private string name;

        //hacky workaround
        [ObservableProperty]
        private string error;

        [ObservableProperty]
        private string mod;

        [ObservableProperty]
        private string glassware;

        [ObservableProperty]
        private string ice;

        [ObservableProperty]
        private string garnish;

        [ObservableProperty]
        private string link;

        [ObservableProperty]
        private string image;

        [ObservableProperty]
        private string drinkTags;

        [ObservableProperty]
        private string ingredientName;

        [ObservableProperty]
        private string ingType;

        [ObservableProperty]
        private float ingredientOz;

        [ObservableProperty]
        private string ingredientSpecial;

        [ObservableProperty]
        private string ingredientTags;

        [ObservableProperty]
        private string notes;


        [RelayCommand]
        void AddIngredient()
        {
            // Validate the IngredientName property
            if (string.IsNullOrWhiteSpace(IngredientName))
            {
                Error = "Error: IngredientName is required.";
                return;
            }

            // Validate the IngredientOz property
            //if (!float.TryParse(IngredientOz, out float oz))
            //{
            //    Error = "Error: IngredientOz must be a valid float value.";
            //    return;
            //}

            // Create a new Ingredient object and set its properties
            Ingredient ingredient = new Ingredient();
            ingredient.Name = IngredientName.Trim();
            ingredient.Type = IngType?.Trim() ?? string.Empty;
            ingredient.Oz = IngredientOz;
            ingredient.Special = IngredientSpecial?.Trim() ?? string.Empty;
            ingredient.Tags = IngredientTags?.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)).ToList() ?? new List<string>();

            ingredients.Add(ingredient);
            Console.WriteLine("Ingredient added successfully.");
            IngredientClear.Invoke(this, null);
        }

        [RelayCommand]
        async void AddDrink()
        {
            // Validate the Name property
            if (string.IsNullOrWhiteSpace(Name))
            {
                Error = ("Error: Name is required.");
                return;
            }

            // Validate the Ingredients property
            if (ingredients == null || ingredients.Count == 0)
            {
                Error = ("Error: At least one ingredient is required.");
                return;
            }

            // Create a new Drink object and set its properties
            Drink drink = new Drink();
            drink.Name = Name.Trim();
            drink.Mod = Mod?.Trim() ?? string.Empty;
            drink.Glassware = Glassware?.Trim() ?? string.Empty;
            drink.Ice = Ice?.Trim() ?? string.Empty;
            drink.Garnish = Garnish?.Trim() ?? string.Empty;
            drink.Link = Link;
            drink.Tags = DrinkTags?.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)).ToList() ?? new List<string>();
            drink.Imgs = Image?.Trim() ?? string.Empty;
            drink.Notes = Notes?.Trim() ?? string.Empty;
            drink.Ingredients = ingredients.ToList<Models.Ingredient>();

            // Add the Drink object to the data store
            try
            {
                Services.DataStore.AddDrink(drink);
                
            }
            catch (Exception ex)
            {
                Error = ("Error adding drink: " + ex.Message);
                
            }
            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
