namespace lab2.Navigation_Miftiev_
{
    public partial class MainPage : ContentPage
    {
    

        public MainPage()
        {
            InitializeComponent();
        }


        private void InBut_click(object sender, EventArgs e)
        {

        }

        private void log_TextChanged(object sender, TextChangedEventArgs e)
        {
            string login = log.Text;
        }

        private void pass_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password = pass.Text;
        }

        private void RegBut_click(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(RegistrationPage));
        }


    }

}
