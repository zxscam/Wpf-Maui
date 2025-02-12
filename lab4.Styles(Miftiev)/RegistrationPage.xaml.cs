namespace lab4.Styles_Miftiev_;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    private void BackBut_click(object sender, EventArgs e)
    {
        AppShell.Current.GoToAsync("..");
    }

    private void SaveBut_Clicked(object sender, EventArgs e)
    {
        string login = RegLog.Text;
        string pass = RegPass.Text;



        if (!string.IsNullOrWhiteSpace(login) &&
          !string.IsNullOrWhiteSpace(pass))
        {
            bool UserLogin = ApplicationData.users.Any(x => x.Login == login);
            if (UserLogin)
            {
                AppShell.Current.DisplayAlert("Ошибка", "Пользователь с таким именем уже существует!", "ОК");
                return;
            }
            else
            {
                ApplicationData.users.Add(new Users(ApplicationData.users.Count + 1, login, pass));
                AppShell.Current.DisplayAlert("Успешно", "Аккаунт успешно зарегестрирован!", "ОК");
                AppShell.Current.GoToAsync("..", true);
            }

        }
        else
        {
            AppShell.Current.DisplayAlert("Предупреждение", "Одно или несколько полей незаполнены!", "ОК");
            return;
        }
    }   
}