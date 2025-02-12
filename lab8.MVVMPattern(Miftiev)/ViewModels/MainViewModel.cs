using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using lab8.MVVMPattern_Miftiev_.Models;
using lab8.MVVMPattern_Miftiev_.Views;

namespace lab8.MVVMPattern_Miftiev_.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string lastAction;

        [ObservableProperty]
        private static int userCount;

        [ObservableProperty]
        private static List<Users> users = [];

        [ObservableProperty]
        private string login;

        [ObservableProperty]
        private string password;

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
            lastAction = "Добавил пользователя в список!";
        }

        [RelayCommand]
        private async Task ShowAllUsersAsync()
        {
            foreach (Users user in users)
            {
                await AppShell.Current.DisplayAlert("Информация", $"Идентификатор пользователя: {user.Id}; Логин пользователя: {user.Login}.", "ОК");
            }
            lastAction = "Показал данные о пользователях!";
        }

        [RelayCommand]
        private async Task ClearUserListPropertiesAsync()
        {
            users = [];
            userCount = 0;
            lastAction = "Очистил пользователей";
        }

        [RelayCommand]
        private async Task GoToRegPage()
        {
            await AppShell.Current.GoToAsync(nameof(RegistrationView));
            lastAction = "Перешел на регистрацию";
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
                await AppShell.Current.GoToAsync(nameof(MainView));
            }
            else
            {
                await AppShell.Current.DisplayAlert("Ошибка", "пользователь не найден", "ОК");
            }
            lastAction = "вошел в систему";
        }
    }
}