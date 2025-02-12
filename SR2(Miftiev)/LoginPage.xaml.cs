using Microsoft.EntityFrameworkCore;

namespace SR2_Miftiev_;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        using (var context = new MusicCollectionContext())
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Login == LoginEntry.Text);
            if (user != null && BCrypt.Net.BCrypt.Verify(PasswordEntry.Text, user.PasswordHash))
            {
                await DisplayAlert("Успех", "Вы вошли в систему!", "OK");
                await Navigation.PushAsync(new PlaylistsPage());
            }
            else
            {
                await DisplayAlert("Ошибка", "Неправильный логин или пароль.", "OK");
            }
        }
    }
}