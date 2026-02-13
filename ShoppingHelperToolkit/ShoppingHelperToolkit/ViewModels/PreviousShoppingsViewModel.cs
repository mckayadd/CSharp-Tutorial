using CommunityToolkit.Mvvm.ComponentModel;
using ShoppingHelperToolkit.Models;
using ShoppingHelperToolkit.Services;
using System.Collections.ObjectModel;
using System.IO;

namespace ShoppingHelperToolkit.ViewModels;

public class PreviousShoppingsViewModel : ObservableObject
{
    private readonly ShoppingJsonService _jsonService = new();

    public ObservableCollection<Shopping> Shoppings { get; } = new();

    private Shopping? _selectedShopping;
    public Shopping? SelectedShopping
    {
        get => _selectedShopping;
        set => SetProperty(ref _selectedShopping, value);
    }

    public void LoadSeedData()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "seed-shoppings.json");

        var loaded = _jsonService.LoadFromFile(filePath);

        Shoppings.Clear();

        // newest first
        foreach (var s in loaded.OrderByDescending(x => x.Date))
            Shoppings.Add(s);

        // auto select first
        if (Shoppings.Count > 0)
            SelectedShopping = Shoppings[0];
    }
    public void AddShopping(Shopping shopping)
    {
        // Add newest on top
        Shoppings.Insert(0, shopping);
        SelectedShopping = shopping;
    }


}
