using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingHelperToolkit.Models;
using ShoppingHelperToolkit.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Globalization;

namespace ShoppingHelperToolkit.ViewModels;

public class PreviousShoppingsViewModel : ObservableObject
{
    
    public PreviousShoppingsViewModel() 
    {
        FilterCommand = new RelayCommand(OnFilter);
    }

    private string _priceThreshold = "";

    public string PriceThreshold
    {
        get { return _priceThreshold; }
        set { _priceThreshold = value; }
    }


    private readonly ShoppingJsonService _jsonService = new();

    public ObservableCollection<Shopping> Shoppings { get; } = new();
    public ObservableCollection<ShoppingItem> FilteredItems { get; } = new();

    public IRelayCommand FilterCommand { get; }

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

    private void OnFilter()
    {
        System.Windows.MessageBox.Show("Raw text value: [" + PriceThreshold + "]");


        if (SelectedShopping == null)
        {
            System.Windows.MessageBox.Show("Please select a shopping first.");
            return;
        }

        bool ok =
       decimal.TryParse(PriceThreshold, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal threshold)
       || decimal.TryParse(PriceThreshold, NumberStyles.Number, CultureInfo.InvariantCulture, out threshold);

        if (!ok)
        {
            System.Windows.MessageBox.Show("Please enter a valid number (e.g., 50 or 50,5 or 50.5).");
            return;
        }


        var result = SelectedShopping.Items
            .Where(item => item.Price > threshold)
            .OrderByDescending(item => item.Price)
            .ToList();

        FilteredItems.Clear();

        foreach (var item in result)
            FilteredItems.Add(item);

        System.Windows.MessageBox.Show("Filtered items count: " + FilteredItems.Count);
    }


}
