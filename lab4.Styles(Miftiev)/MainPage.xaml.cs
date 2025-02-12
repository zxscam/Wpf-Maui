using Android.Util;

namespace lab4.Styles_Miftiev_
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void RegBut_click(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(RegistrationPage));
        }

        private void InBut_Clicked(object sender, EventArgs e)
        {
            string login = log.Text;
            string pass = pas.Text;

            if (!string.IsNullOrWhiteSpace(login) &&
              !string.IsNullOrWhiteSpace(pass))
            {
                bool UserLogin = ApplicationData.users.Any(x => x.Login == login);
                bool UserPass = ApplicationData.users.Any(x => x.Password == pass);
                if (UserLogin && UserPass)
                {
                    AppShell.Current.GoToAsync("//" + nameof(MenuPage), true);
                }
                else
                {
                    AppShell.Current.DisplayAlert("Ошибка", "Пользователя с таким именем не существует!", "ОК");
                    return;
                }

            }

            else
            {
                AppShell.Current.DisplayAlert("Предупреждение", "Одно или несколько полей незаполнены!", "ОК");
                return;
            }
        }

    }

}
