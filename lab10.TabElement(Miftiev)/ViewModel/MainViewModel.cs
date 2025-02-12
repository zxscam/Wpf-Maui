﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using lab10.TabElement_Miftiev_.Models;
using lab10.TabElement_Miftiev_.Views;

namespace lab10.TabElement_Miftiev_.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private static int userCount;

        [ObservableProperty]
        private string login;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private static List<Users> users = [];

        [RelayCommand]
        private async Task AddUserInListAsync()
        {
            bool isNameEmpty = string.IsNullOrWhiteSpace(login);
            if (isNameEmpty)
            {
                await AppShell.Current.DisplayAlert("Ошибка", "Логин не может быть пустым", "ОК");
                return;
            }

            bool isOwnerEmpty = string.IsNullOrWhiteSpace(password);
            if (isOwnerEmpty)
            {
                await AppShell.Current.DisplayAlert("Ошибка", "Пароль не может быть пустым", "ОК");
                return;
            }
            userCount++;
            users.Add(new Users(userCount, login, password));

            login = string.Empty;
            password = string.Empty;
        }

        [RelayCommand]
        private async Task InButAsync()
        {
            bool isNameEmpty = string.IsNullOrWhiteSpace(login);
            if (isNameEmpty)
            {
                await AppShell.Current.DisplayAlert("Ошибка", "Логин не может быть пустым", "ОК");
                return;
            }

            bool isOwnerEmpty = string.IsNullOrWhiteSpace(password);
            if (isOwnerEmpty)
            {
                await AppShell.Current.DisplayAlert("Ошибка", "Пароль не может быть пустым", "ОК");
                return;
            }

            bool log = false;
            bool pass = false;

            for (int j = 0; j < userCount; j++)
            {
                if (login == users[j].Login) log = true;
                if (password == users[j].Password) pass = true;
            }

            if (log == true && pass == true)
            {
                await AppShell.Current.GoToAsync(nameof(MenuPage));
            }
            else
            {
                await AppShell.Current.DisplayAlert("Ошибка", "пользователь не найден", "ОК");
            }
        }

        [RelayCommand]
        private async Task GoToRegPage()
        {
            await AppShell.Current.GoToAsync(nameof(RegistrationPage));
        }
    }   
}
