using lab9.MVVMTransferData_Miftiev_.ViewModels;

namespace lab9.MVVMTransferData_Miftiev_.Views;

public partial class SecondPage : ContentPage
{
	public SecondPage()
	{
		InitializeComponent();
        BindingContext = new SecondViewModel();
    }
}