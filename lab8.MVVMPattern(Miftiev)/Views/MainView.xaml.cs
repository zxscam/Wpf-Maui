using lab8.MVVMPattern_Miftiev_.ViewModels;

namespace lab8.MVVMPattern_Miftiev_.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();

        BindingContext = new MainViewModel();
    }
}