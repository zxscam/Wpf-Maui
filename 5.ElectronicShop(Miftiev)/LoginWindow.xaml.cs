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
using System.Windows.Shapes;
using ElectronicShop_Miftiev_.DatabaseContext;
using ElectronicShop_Miftiev_.Entities;

namespace ElectronicShop_Miftiev_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
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
            string login = LoginTextBox.Text;
            string password = PasswordBox.Text;

            if (login != string.Empty && password != string.Empty)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                bool isLoginAlreadyExist = dbContext.Users.Any(p => p.Login == login);
                bool isPassAlreadyExist = dbContext.Users.Any(p => p.Password == password);
                if (isLoginAlreadyExist && isPassAlreadyExist)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует!", "Ошибка");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Одно или несколько полей незаполнены!", "Предупреждение");
                return;
            }
        }
    }
}

          