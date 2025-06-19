namespace ExamGO;

public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; }

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        ServiceProvider = serviceProvider;

        MainPage = new AppShell();
    }
}
