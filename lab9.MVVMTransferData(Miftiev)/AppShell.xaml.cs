using lab9.MVVMTransferData_Miftiev_.Views;

namespace lab9.MVVMTransferData_Miftiev_
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));
            Routing.RegisterRoute(nameof(FirstPage), typeof(FirstPage));
        }
    }
}
