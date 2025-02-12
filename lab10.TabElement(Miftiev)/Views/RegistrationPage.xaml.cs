using lab10.TabElement_Miftiev_.ViewModel;

namespace lab10.TabElement_Miftiev_.Views;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
    }
}