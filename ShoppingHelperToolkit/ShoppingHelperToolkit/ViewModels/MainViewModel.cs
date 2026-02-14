using CommunityToolkit.Mvvm.ComponentModel;

namespace ShoppingHelperToolkit.ViewModels;

public class MainViewModel : ObservableObject
{
    public string Title { get; } = "Shopping Helper (Toolkit MVVM)";

    public PreviousShoppingsViewModel Previous { get; }
    public CreateListViewModel CreateList { get; }

    public MainViewModel()
    {
        Previous = new PreviousShoppingsViewModel();
        Previous.LoadSeedData();

        // Give CreateList access to Previous so it can "Save Shopping" into it
        CreateList = new CreateListViewModel(Previous);
    }
}
