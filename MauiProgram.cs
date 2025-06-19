using ExamGO.Services;

namespace ExamGO;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>() // Подключаем App вручную ниже
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Регистрация сервисов
        builder.Services.AddSingleton<IDataService, InMemoryDataService>();

        // Регистрируем App и передаём в него сервис-провайдер
        builder.Services.AddSingleton<App>(sp => new App(sp));

        return builder.Build();
    }
}
