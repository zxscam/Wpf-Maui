using lab10.TabElement_Miftiev_.ViewModel;

namespace lab10.TabElement_Miftiev_.Views;

public partial class AuthorPage : ContentPage
{
	public AuthorPage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
    }
}