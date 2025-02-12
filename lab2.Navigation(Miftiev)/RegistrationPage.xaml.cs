namespace lab2.Navigation_Miftiev_;

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

    private void RegLog_TextChanged(object sender, TextChangedEventArgs e)
    {
        string login = RegLog.Text;
    }

    private void RegPass_TextChanged(object sender, TextChangedEventArgs e)
    {
        string password = RegPass.Text;
    }

    private void SaveBut_Clicked(object sender, EventArgs e)
    {

    }
}