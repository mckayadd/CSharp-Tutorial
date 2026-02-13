using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingHelperToolkit.Models;
using System.Collections.ObjectModel;

namespace ShoppingHelperToolkit.ViewModels;

public class CreateListViewModel : ObservableObject
{
    // We use a callback so this ViewModel can "save" without knowing about the other ViewModel directly.
    private readonly Action<Shopping> _onSaveShopping;

    public ObservableCollection<ShoppingItem> CurrentItems { get; } = new();

    private string _itemName = "";
    public string ItemName
    {
        get => _itemName;
        set
        {
            SetProperty(ref _itemName, value);
            AddItemCommand.NotifyCanExecuteChanged();
        }
    }

    private string _priceText = "";
    public string PriceText
    {
        get => _priceText;
        set
        {
            SetProperty(ref _priceText, value);
            AddItemCommand.NotifyCanExecuteChanged();
        }
    }

    private string _statusMessage = "";
    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public RelayCommand AddItemCommand { get; }
    public RelayCommand SaveShoppingCommand { get; }

    public CreateListViewModel(Action<Shopping> onSaveShopping)
    {
        _onSaveShopping = onSaveShopping;

        AddItemCommand = new RelayCommand(AddItem, CanAddItem);
        SaveShoppingCommand = new RelayCommand(SaveShopping, CanSaveShopping);
    }

    private bool CanAddItem()
    {
        if (string.IsNullOrWhiteSpace(ItemName))
            return false;

        // Price must be a number >= 0
        if (!decimal.TryParse(PriceText, out decimal p))
            return false;

        return p >= 0;
    }

    private void AddItem()
    {
        decimal price = decimal.Parse(PriceText);

        CurrentItems.Add(new ShoppingItem
        {
            Name = ItemName.Trim(),
            Price = price
        });

        // reset inputs
        ItemName = "";
        PriceText = "";
        StatusMessage = "Item added.";

        SaveShoppingCommand.NotifyCanExecuteChanged();
    }

    private bool CanSaveShopping()
    {
        return CurrentItems.Count > 0;
    }

    private void SaveShopping()
    {
        var shopping = new Shopping
        {
            Date = DateTime.Now,
            Items = CurrentItems.ToList()
        };

        _onSaveShopping(shopping);

        CurrentItems.Clear();
        StatusMessage = "Shopping saved.";

        SaveShoppingCommand.NotifyCanExecuteChanged();
    }
}
