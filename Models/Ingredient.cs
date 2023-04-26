
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drink_Book_Data_Entry_App.Models;

public class Ingredient
{
    public string Name { get; set; }
    public float? Oz { get; set; }
    public string? Special { get; set; }
    public string? Type { get; set; }
    public List<string>? Tags { get; set; } = new List<string>();

    public Ingredient() { }
}
