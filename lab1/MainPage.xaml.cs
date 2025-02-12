namespace lab1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void InBut_ckick(object sender, EventArgs e)
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

        private void RegBut_ckick(object sender, EventArgs e)
        {

        }
    }

}
