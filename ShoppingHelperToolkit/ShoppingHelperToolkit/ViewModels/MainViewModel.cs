using CommunityToolkit.Mvvm.ComponentModel;

namespace ShoppingHelperToolkit.ViewModels;

public class MainViewModel : ObservableObject
{
    public string Title { get; } = "Shopping Helper (Toolkit MVVM)";

    public PreviousShoppingsViewModel Previous { get; } = new();
    public CreateListViewModel CreateList { get; }

    public MainViewModel()
    {
        Previous.LoadSeedData();

        // connect: when CreateList saves a shopping, add it to Previous
        CreateList = new CreateListViewModel(Previous.AddShopping);
    }
}
