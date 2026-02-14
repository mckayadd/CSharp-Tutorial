using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    private string _priceThreshold = "";
    public string PriceThreshold
    {
        get => _priceThreshold;
        set => SetProperty(ref _priceThreshold, value);
    }

    public ObservableCollection<ShoppingItem> FilteredItems { get; } = new();

    public IRelayCommand FilterCommand { get; }

    public PreviousShoppingsViewModel()
    {
        FilterCommand = new RelayCommand(OnFilter);
    }

    public void LoadSeedData()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "seed-shoppings.json");

        var loaded = _jsonService.LoadFromFile(filePath);

        Shoppings.Clear();

        foreach (var s in loaded.OrderByDescending(x => x.Date))
            Shoppings.Add(s);

        if (Shoppings.Count > 0)
            SelectedShopping = Shoppings[0];
    }

    public void AddShoppingOnTop(Shopping shopping)
    {
        Shoppings.Insert(0, shopping);
        SelectedShopping = shopping;

        // Optional: clear filtered list because selection changed
        FilteredItems.Clear();
    }

    private void OnFilter()
    {
        if (SelectedShopping == null)
        {
            System.Windows.MessageBox.Show("Please select a shopping first.");
            return;
        }

        if (!decimal.TryParse(PriceThreshold, out decimal threshold))
        {
            System.Windows.MessageBox.Show("Please enter a valid number (example: 50 or 50.5).");
            return;
        }

        var result = SelectedShopping.Items
            .Where(item => item.Price > threshold)
            .OrderByDescending(item => item.Price)
            .ToList();

        FilteredItems.Clear();
        foreach (var item in result)
            FilteredItems.Add(item);
    }
}
