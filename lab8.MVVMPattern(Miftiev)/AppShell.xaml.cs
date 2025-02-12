using lab8.MVVMPattern_Miftiev_.Views;

namespace lab8.MVVMPattern_Miftiev_
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(RegistrationView), typeof(RegistrationView));
            Routing.RegisterRoute(nameof(MainView), typeof(MainView));
        }
    }
}
