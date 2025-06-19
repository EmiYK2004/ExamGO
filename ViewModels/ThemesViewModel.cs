using ExamGO.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExamGO.Model;
public class ThemesViewModel : INotifyPropertyChanged
{
    private readonly IDataService _dataService;

    public ObservableCollection<Theme> Themes { get; } = new();

    private string _newThemeTitle;
    public string NewThemeTitle
    {
        get => _newThemeTitle;
        set
        {
            _newThemeTitle = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddThemeCommand { get; }
    public ICommand DeleteThemeCommand { get; }

    public ThemesViewModel(IDataService dataService)
    {
        _dataService = dataService;

        AddThemeCommand = new Command(async () => await AddThemeAsync());
        DeleteThemeCommand = new Command<Theme>(async theme => await DeleteThemeAsync(theme));

        _ = LoadThemesAsync();
    }

    private async Task LoadThemesAsync()
    {
        Themes.Clear();
        var themes = await _dataService.GetThemesAsync();
        foreach (var theme in themes)
            Themes.Add(theme);
    }

    private async Task AddThemeAsync()
    {
        if (string.IsNullOrWhiteSpace(NewThemeTitle)) return;

        var newTheme = new Theme { Title = NewThemeTitle };
        await _dataService.AddThemeAsync(newTheme);
        NewThemeTitle = string.Empty;

        await LoadThemesAsync();
    }

    private async Task DeleteThemeAsync(Theme theme)
    {
        if (theme == null) return;

        await _dataService.DeleteThemeAsync(theme.Id);
        await LoadThemesAsync();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
