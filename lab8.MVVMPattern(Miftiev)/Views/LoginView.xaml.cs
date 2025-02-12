using lab8.MVVMPattern_Miftiev_.ViewModels;

namespace lab8.MVVMPattern_Miftiev_.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();

        BindingContext = new MainViewModel();
    }
}