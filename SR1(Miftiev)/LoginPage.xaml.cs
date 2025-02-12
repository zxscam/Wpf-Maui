using Microsoft.Maui.Controls;
using System.IO;
using System.Linq;

namespace SR1_Miftiev_;

public partial class LoginPage : ContentPage
{
    private bool isPasswordVisible = false;
    private Database _database;

    public LoginPage()
    {
        InitializeComponent();
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
        _database = new Database(dbPath);
    }

    private void OnTogglePasswordVisibilityClicked(object sender, EventArgs e)
    {
        isPasswordVisible = !isPasswordVisible;
        passwordEntry.IsPassword = !isPasswordVisible;
        togglePasswordVisibilityButton.Source = isPasswordVisible ? "eye_open.jpg" : "eye_closed.png";
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = usernameEntry.Text; // Изменил имя переменной на email для соответствия
        string password = passwordEntry.Text;

        // Проверяем, что поля не пустые
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Ошибка", "Пожалуйста, введите имя пользователя и пароль.", "OK");
            return;
        }

        // Проверяем аутентификацию пользователя
        bool isAuthenticated = await AuthenticateUser(email, password);

        if (isAuthenticated)
        {
            await DisplayAlert("Успех", "Вы вошли в систему!", "OK");
            // Перейти на главную страницу после успешного входа
            await Navigation.PushAsync(new LoginPage()); // Замените MainPage на вашу главную страницу
        }
        else
        {
            await DisplayAlert("Ошибка", "Неверное имя пользователя или пароль.", "OK");
        }
    }

    // Метод для аутентификации пользователя
    private async Task<bool> AuthenticateUser(string email, string password)
    {
        var users = await _database.GetUsersAsync();

        // Проверяем, существует ли пользователь с указанным email и паролем
        return users.Any(u => u.Email == email && u.Password == password); // Лучше использовать хэш пароля
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}
