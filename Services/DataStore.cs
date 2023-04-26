using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Drink_Book_Data_Entry_App.Services;

public static class DataStore
{
    private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static void AddDrink(Models.Drink drink)
    {
        //Drinks for the sake of keeping the system able to move storage types will be in XML

        var settings = new XmlWriterSettings()
        {
            Indent = true,
            OmitXmlDeclaration = true,
            NewLineOnAttributes = true,
            Async = true
        };

        var serializer = new XmlSerializer(typeof(List<Models.Drink>));
        List<Models.Drink> drinks = new List<Models.Drink>();
        //Check if we have the file...

        if(File.Exists(path + "//drinks.xml"))
        {
            using (var reader = XmlReader.Create(path + "//drinks.xml"))
            {
                drinks = (List<Models.Drink>)serializer.Deserialize(reader);
            }
        }

        //Adds the drink
        drinks.Add(drink);
        
        

        using (XmlWriter writer = XmlWriter.Create(path + "//drinks.xml", settings))
        {
            serializer.Serialize(writer, drinks);
        }

    }

    public static void UpdateDrinkList(List<Models.Drink> drinks)
    {
        var settings = new XmlWriterSettings()
        {
            Indent = true,
            OmitXmlDeclaration = true,
            NewLineOnAttributes = true,
            Async = true
        };
        var serializer = new XmlSerializer(typeof(List<Models.Drink>));
        using (XmlWriter writer = XmlWriter.Create(path + "//drinks.xml", settings))
        {
            serializer.Serialize(writer, drinks);
        }

    }

    public static List<Models.Drink> GetDrinks()
    {
        List<Models.Drink> drinks = new List<Models.Drink>();

        var serializer = new XmlSerializer(typeof(List<Models.Drink>));

        //Check if we have the file...

        if (File.Exists(path + "//drinks.xml"))
        {
            using (var reader = XmlReader.Create(path + "//drinks.xml"))
            {
                drinks = (List<Models.Drink>)serializer.Deserialize(reader);
            }
        }
        return drinks;
    }
}
