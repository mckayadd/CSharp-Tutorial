using ShoppingHelper.Infrastructure;

namespace ShoppingHelper.ViewModels;

public class MainViewModel : ObservableObject
{
    public string Title { get; } = "Shopping Helper (Manual MVVM)";

    public CreateListViewModel CreateList { get; } = new();
    public PreviousShoppingsViewModel Previous { get; } = new();
}
