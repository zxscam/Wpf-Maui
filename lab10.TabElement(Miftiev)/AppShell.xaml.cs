using lab10.TabElement_Miftiev_.Views;

namespace lab10.TabElement_Miftiev_
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AuthorPage), typeof(AuthorPage));
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        }
    }
}
