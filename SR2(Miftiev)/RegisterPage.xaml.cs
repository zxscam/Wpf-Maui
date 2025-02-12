using Microsoft.Extensions.Logging.Abstractions;
using System;
using Microsoft.Maui.Controls;

namespace SR2_Miftiev_;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var user = new User
        {
            LastName = LastNameEntry.Text,
            FirstName = FirstNameEntry.Text,
            MiddleName = MiddleNameEntry.Text,
            Login = LoginEntry.Text,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(PasswordEntry.Text) // Хэшируем пароль
        };

        using (var context = new MusicCollectionContext())
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        await DisplayAlert("Успех", "Пользователь зарегистрирован!", "OK");
        await Navigation.PushAsync(new LoginPage());
    }

}