using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGenericHost2.Models;
using WPFGenericHost2.Services;

namespace WPFGenericHost2.ViewModels
{
    public partial class Window1ViewModel : ObservableObject, IRecipient<StringMessage>
    {
        private readonly ApplicationDbContext _context;
        private readonly ITextService _textService;
        string[] _titles = { "Excellent", "Good", "Super", "REALLY GOOD DOCTOR!", "THANK YOU!", "THE BEST", "EXCELLENT PHYSICIAN", "EXCELLENT DOCTOR" };


        [ObservableProperty]
        private string? _helloText;

        public ObservableCollection<Title> ListTitles { get; set; } = new();

        [ObservableProperty]
        private Title? _selectedTitle;

        [ObservableProperty]
        private string? _message;


        /// <summary>
        /// 用于依赖注入的构造函数
        /// </summary>
        /// <param name="textService">用于依赖注入</param>
        public Window1ViewModel(ITextService textService, ApplicationDbContext context)
        {
            _textService = textService;
            HelloText = _textService.GetText();
            WeakReferenceMessenger.Default.RegisterAll(this);
            _context = context;
            _context.Titles.Load();
            ListTitles = _context.Titles.Local.ToObservableCollection();
        }

        [RelayCommand]
        private async Task AddItemAsync()
        {
            var titleString = _titles[new Random().Next(0, _titles.Length)];
            var title = new Title { TitleString = titleString };
            await _context.AddAsync(title);
            await _context.SaveChangesAsync();
        }

        [RelayCommand]
        private async Task RemoveItemAsync()
        {
            if (SelectedTitle is not null)
            {
                ListTitles.Remove(SelectedTitle);
                await _context.SaveChangesAsync();
            }
        }

        public void Receive(StringMessage message)
        {
            Message = message.Value;
        }
    }
}
