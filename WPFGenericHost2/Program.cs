// Create a builder by specifying the application and main window.
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System.IO;
using System.Runtime;
using WPFGenericHost2;
using WPFGenericHost2.Services;
using WPFGenericHost2.ViewModels;
using WPFGenericHost2.Views;

var builder = WpfApplication<App, MainWindow>.CreateBuilder(args);

builder.Environment.ContentRootPath = Directory.GetCurrentDirectory();
builder.Configuration.AddJsonFile("appsettings.json", optional: true);
builder.Services.Configure<MySettings>(builder.Configuration.GetSection(MySettings.Position));

// Configure dependency injection.
// Injecting MainWindowViewModel into MainWindow.
//builder.Services.AddTransient<MainViewModel>();
builder.Services.AddSingleton<ITextService, TextService>();
builder.Services.AddSingleton<MainViewModel>();
builder.Services.AddTransient<Window1>();
builder.Services.AddTransient<Window1ViewModel>();

builder.Logging.AddDebug();

var app = builder.Build();
ServiceLocator.Services = app.Services;

await app.RunAsync();