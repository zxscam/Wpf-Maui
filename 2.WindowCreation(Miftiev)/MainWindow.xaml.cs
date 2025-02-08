using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowCreation_Miftiev_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenRegistrationWindow(object sender, RoutedEventArgs e)
        {
            var RegistrationWindow = new RegistrationWindow();
            RegistrationWindow.ShowDialog();
        }

        private void OpenMenuWindow(object sender, RoutedEventArgs e)
        {
            var MenuWindow = new MenuWindow();
            App.Current.MainWindow = MenuWindow;
            MenuWindow.Show();
            Close();
        }
    }
}
