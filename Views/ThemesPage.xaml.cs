using ExamGO.Services;


namespace ExamGO.Views;

public partial class ThemesPage : ContentPage
{
    public ThemesPage()
    {
        InitializeComponent();

        var dataService = (Application.Current as App)?.ServiceProvider?.GetService<IDataService>();
        BindingContext = new ThemesViewModel(dataService!);
    }
}
