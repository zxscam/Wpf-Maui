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
using System.Xml.Linq;

namespace ElectronicShop_Miftiev_
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

            if (login != string.Empty && password != string.Empty)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                bool isLoginAlreadyExist = dbContext.Users.Any(p => p.Login == login);
                if (isLoginAlreadyExist)
                {
                    MessageBox.Show("Пользователь с данным логином уже существует!", "Ошибка");
                    return;
                }
                else
                {
                    UsersEntity user = new UsersEntity(login, password); dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                    MessageBox.Show("Пользователь успешно зарегистрирован!", "Успех");
                    Close();
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
