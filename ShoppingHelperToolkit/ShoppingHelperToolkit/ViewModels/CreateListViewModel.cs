using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingHelperToolkit.Models;
using System.Collections.ObjectModel;

namespace ShoppingHelperToolkit.ViewModels;

public class CreateListViewModel : ObservableObject
{
    private readonly PreviousShoppingsViewModel _previous;

    public ObservableCollection<ShoppingItem> CurrentItems { get; } = new();

    private string _newItemName = "";
    public string NewItemName
    {
        get => _newItemName;
        set => SetProperty(ref _newItemName, value);
    }

    private string _newItemPrice = "";
    public string NewItemPrice
    {
        get => _newItemPrice;
        set => SetProperty(ref _newItemPrice, value);
    }

    public IRelayCommand AddItemCommand { get; }
    public IRelayCommand SaveShoppingCommand { get; }
    public IRelayCommand ClearCurrentCommand { get; }

    public CreateListViewModel(PreviousShoppingsViewModel previous)
    {
        _previous = previous;

        AddItemCommand = new RelayCommand(OnAddItem);
        SaveShoppingCommand = new RelayCommand(OnSaveShopping);
        ClearCurrentCommand = new RelayCommand(OnClearCurrent);
    }

    private void OnAddItem()
    {
        // 1) Validate name
        if (string.IsNullOrWhiteSpace(NewItemName))
        {
            System.Windows.MessageBox.Show("Please enter an item name.");
            return;
        }

        // 2) Validate & parse price
        if (!decimal.TryParse(NewItemPrice, out decimal price))
        {
            System.Windows.MessageBox.Show("Please enter a valid price (example: 25 or 25.5).");
            return;
        }

        if (price < 0)
        {
            System.Windows.MessageBox.Show("Price cannot be negative.");
            return;
        }

        // 3) Add to list
        CurrentItems.Add(new ShoppingItem
        {
            Name = NewItemName.Trim(),
            Price = price
        });

        // 4) Clear inputs for next item
        NewItemName = "";
        NewItemPrice = "";
    }

    private void OnSaveShopping()
    {
        if (CurrentItems.Count == 0)
        {
            System.Windows.MessageBox.Show("Your current list is empty. Add items first.");
            return;
        }

        // Create a new shopping session
        var shopping = new Shopping
        {
            Date = DateTime.Now,
            Items = CurrentItems.ToList()
        };

        // Add it to the Previous tab (latest first)
        _previous.AddShoppingOnTop(shopping);

        // Clear current list
        CurrentItems.Clear();

        System.Windows.MessageBox.Show("Shopping saved to Previous Shoppings!");
    }

    private void OnClearCurrent()
    {
        CurrentItems.Clear();
        NewItemName = "";
        NewItemPrice = "";
    }
}
