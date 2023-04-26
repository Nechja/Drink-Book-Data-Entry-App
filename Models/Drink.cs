using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drink_Book_Data_Entry_App.Models;

public class Drink
{
    public string Name { get; set; }
    public string? Mod { get; set; }
    public string Glassware { get; set; }
    public string? Ice { get; set; }
    public string? Garnish { get; set; }
    public string? Notes { get; set; }
    public string? Link { get; set; }
    public string? Imgs { get; set; }

    public List<string> Tags { get; set; } = new List<string>();

    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public Drink() { }

}
