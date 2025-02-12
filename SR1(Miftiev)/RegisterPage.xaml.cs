namespace SR1_Miftiev_;

public partial class RegisterPage : ContentPage
{
    private Database _database;

    public RegisterPage()
    {
        InitializeComponent();
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
        _database = new Database(dbPath);
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Получаем значения из полей ввода
        string email = emailEntry.Text;
        string password = passwordEntry.Text;
        string confirmPassword = confirmPasswordEntry.Text;

        // Проверка на пустые значения
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Ошибка", "Все поля должны быть заполнены.", "OK");
            return;
        }

        // Проверка на совпадение паролей
        if (password != confirmPassword)
        {
            await DisplayAlert("Ошибка", "Пароли не совпадают.", "OK");
            return;
        }

        // Создаем нового пользователя
        var newUser = new User
        {
            Email = email,
            Password = password // Рекомендуется хранить хэш пароля, а не сам пароль
        };

        // Сохраняем данные пользователя в базе данных
        await _database.SaveUserAsync(newUser);

        await DisplayAlert("Успех", "Регистрация прошла успешно!", "OK");
        await Navigation.PushAsync(new LoginPage()); // Перейти на страницу входа
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage()); // Перейти на страницу входа
    }
}

