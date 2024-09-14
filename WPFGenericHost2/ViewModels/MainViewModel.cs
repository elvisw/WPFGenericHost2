// Create a builder by specifying the application and main window.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Reflection;
using System.Windows;
using WPFGenericHost2.Models;
using WPFGenericHost2.Views;

namespace WPFGenericHost2.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? _message;
        [ObservableProperty]
        private string? _location;
        [ObservableProperty]
        private string? _version;

        public MainViewModel(ILogger<MainViewModel> logger)
        {
            logger.LogInformation($"{typeof(MainWindow)} has been loaded.");
            //WeakReferenceMessenger.Default.RegisterAll(this);
            Assembly assembly = Assembly.GetExecutingAssembly();

            Location = assembly.Location;
            Version = assembly.GetName().Version.ToString(3);

        }


        [RelayCommand]
        private void OpenWindow1()
        {
            var window1 = ServiceLocator.Services.GetService<Window1>();
            window1?.Show();
            WeakReferenceMessenger.Default.Send(new StringMessage("Window1 has been opened"));
        }

        [RelayCommand]
        private void SendMessage()
        {
            WeakReferenceMessenger.Default.Send(new StringMessage(Message!));
        }

    }
}