using lab8.MVVMPattern_Miftiev_.ViewModels;

namespace lab8.MVVMPattern_Miftiev_.Views;

public partial class RegistrationView : ContentPage
{
	public RegistrationView()
	{
		InitializeComponent();

        BindingContext = new MainViewModel();
    }
}