namespace lab7.HttpRequestsSending_Miftiev_
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(GetProductPage), typeof(GetProductPage));
            Routing.RegisterRoute(nameof(UpdatePage), typeof(UpdatePage));
            Routing.RegisterRoute(nameof(DeletePage), typeof(DeletePage));
        }
    }
}
