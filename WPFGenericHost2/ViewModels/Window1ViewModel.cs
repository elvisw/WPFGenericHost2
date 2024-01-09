﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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
        private readonly ITextService _textService;
        string[] _titles = { "Excellent", "Good", "Super", "REALLY GOOD DOCTOR!", "THANK YOU!", "THE BEST", "EXCELLENT PHYSICIAN", "EXCELLENT DOCTOR" };


        [ObservableProperty]
        private string? _helloText;

        public ObservableCollection<string> ListTitles { get; set; } = new ObservableCollection<string>();

        [ObservableProperty]
        private string _selectedTitle;

        [ObservableProperty]
        private string? _message;


        /// <summary>
        /// 用于依赖注入的构造函数
        /// </summary>
        /// <param name="textService">用于依赖注入</param>
        public Window1ViewModel(ITextService textService)
        {
            _textService = textService;
            HelloText = _textService.GetText();
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        [RelayCommand]
        private void AddItem()
        {
            ListTitles.Add(_titles[new Random().Next(0, _titles.Length)]);
        }

        [RelayCommand]
        private void RemoveItem() 
        {
            ListTitles.Remove(SelectedTitle);
        }

        public void Receive(StringMessage message)
        {
            Message = message.Value;
        }
    }
}
