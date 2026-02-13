using System.Collections.ObjectModel;
using ShoppingHelper.Infrastructure;
using ShoppingHelper.Models;

namespace ShoppingHelper.ViewModels;

public class PreviousShoppingsViewModel : ObservableObject
{
    public ObservableCollection<Shopping> Shoppings { get; } = new();

    private Shopping? _selectedShopping;
    public Shopping? SelectedShopping
    {
        get => _selectedShopping;
        set => SetProperty(ref _selectedShopping, value);
    }

    // Later we’ll add: Items view + Filter threshold + FilteredItems
}
