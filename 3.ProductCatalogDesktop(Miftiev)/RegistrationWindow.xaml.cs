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

namespace ProductCatalogDesktop_Miftiev_
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void CloseRegistrationWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            string login = loginn.Text;
            string password = passwordd.Text;

            bool isLoginEmpty = string.IsNullOrWhiteSpace(login);
            if (isLoginEmpty)
            {
                MessageBox.Show("Логин не может быть пустым!");
                return;
            }

            bool isPasswordEmpty = string.IsNullOrWhiteSpace(password);
            if (isPasswordEmpty)
            {
                MessageBox.Show("Пароль не может быть пустым!");
                return;
            }

            bool isLoginAlreadyExist = ApplicationData.users.Any(x => x.Login == login);
            if (isLoginAlreadyExist)
            {
                MessageBox.Show("Такой пользователь уже существует!");
                return;
            }

                ApplicationData.users.Add(new user(login, password));

            MessageBox.Show("Вы успешно зарегистрировались!");

            Close();

        }
    }
}
