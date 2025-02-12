using lab9.MVVMTransferData_Miftiev_.ViewModels;

namespace lab9.MVVMTransferData_Miftiev_.Views;
			

public partial class FirstPage : ContentPage
{
	public FirstPage()
	{
		InitializeComponent();
        BindingContext = new FirstViewModel();		
    }
}