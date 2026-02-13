using System.Collections.ObjectModel;
using ShoppingHelper.Infrastructure;
using ShoppingHelper.Models;

namespace ShoppingHelper.ViewModels;

public class CreateListViewModel : ObservableObject
{
    public ObservableCollection<ShoppingItem> CurrentItems { get; } = new();
}
